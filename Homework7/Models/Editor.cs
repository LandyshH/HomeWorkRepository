using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Models
{
    public static class EditorForModel
    {
        public static IHtmlContent OwnEditorForModel(this IHtmlHelper htmlHelper)
        {
            var model = htmlHelper.ViewData.ModelMetadata.ModelType;
            var properties = model.GetProperties();
            var result = properties.Select(x => x.MakeTitleAndInput(htmlHelper.ViewData.Model));
            return new HtmlString(string.Join(" ", result));
        }

        public static string MakeTitleAndInput(this PropertyInfo property, object model)
        {
           return property.MakeTitle() + property.MakeInputAndSpan(model);
        }
        
        public static string MakeTitle(this PropertyInfo property)
        {
            var div = new TagBuilder("div")
            {
                Attributes =
                {
                    {"class", "editor-label"}
                }
            };

            var label = new TagBuilder("label")
            {
                Attributes =
                {
                    {"for", property.Name}
                }
            };
            var name = property.GetCustomAttribute<DisplayNameAttribute>() is null ?

                CamelCase(property.Name) : property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
            return div.InnerHtml.AppendHtml(label).Append(name).GetString();
        }

        private static string CamelCase(string text) =>
            Regex.Replace(text, "([A-Z])", " $1", RegexOptions.Compiled).Trim();


           public static string MakeEnumInput(this PropertyInfo property, object model)
           {
               string list = $"Html.GetEnumSelectList<{property.PropertyType}>()";
               var select = new TagBuilder("select")
               {
                    Attributes =
                    {
                        {"asp-for", property.Name},
                        {"asp-items", list},
                        {"class", "form-control"}
                    }
               };

               return select.GetString();
           }
        public static string MakeInputAndSpan(this PropertyInfo property, object model)
        {
            var value = model is not null ? 
                property.GetValue(model)?.ToString() : "";
            
            var div = new TagBuilder("div")
            {
                Attributes =
                {
                    {"class", "editor-field"}
                }
            };
            
            var typeTextOrNumber = property.PropertyType == typeof(int) ? "number" : "text";

            if (property.PropertyType.IsEnum)
            {
                var select = new TagBuilder("select")
                {
                    Attributes =
                    {
                       {"id", property.Name},
                       {"name", property.Name}
                    }
                };

                var enumCount = Enum.GetNames(property.PropertyType).Length;
                for (var i = 0; i < enumCount; i++)
                {
                    var option = new TagBuilder("option")
                    {
                        Attributes =
                        {
                            {"value", $"{i}"}
                        }
                    };

                    var t = property.PropertyType.GetEnumNames()[i];

                    option.InnerHtml.Append(t);
                    select.InnerHtml.AppendHtml(option);
                }

                div.InnerHtml.AppendHtml(select);
                return div.GetString();
            }

            var input = new TagBuilder("input")
            {
                Attributes =
                {
                    {"class", "text-box single-line"},
                    {"data-val", "true"},
                    {"id", property.Name},
                    {"name", property.Name},
                    {"type", typeTextOrNumber}, {"value", value}
                }
            };
                
            div.InnerHtml.AppendHtml(input);
            var span = property.MakeSpan(model);
            div.InnerHtml.AppendHtml(span);
            return div.GetString();
        }
        
        public static string GetString(this IHtmlContent content)
        {
            using var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        public static IHtmlContent MakeSpan(this PropertyInfo property, object model)
        {
            if (model is null) return null;
            var attrs = property.GetCustomAttributes<ValidationAttribute>();

            return (from attr in attrs where !attr.IsValid(property.GetValue(model)) 
                let span = new TagBuilder("span") 
                    {Attributes = {{"class", "field-validation-valid"}, {"data-valmsg-for", property.Name}, {"data-valmsg-replace", "true"}}}
                select span.InnerHtml.Append(attr.ErrorMessage ?? attr.FormatErrorMessage(property.Name))).FirstOrDefault();
        }
    }
}
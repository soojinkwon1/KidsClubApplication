﻿using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Xml.Linq;
using KidsClubApplication.Models;

namespace KidsClubApplication.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("calendar", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CalendarTagHelper : TagHelper
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public List<CalendarEvent>? Events { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            output.Attributes.Add("class", "calendar");
            output.Content.SetHtmlContent(GetHtml());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        /*public string echo(string Xmonth)
        {
            *//*return splitmonth;
             08/2022*//*
            string[] parts = Xmonth.Split('/');
            int month = int.Parse(parts[0]);
            int year = int.Parse(parts[1]);


        }*/


        private string GetHtml()
        {
            var monthStart = new DateTime(Year, Month, 1);

            var events = Events?.Where(e => e != null && e.Date.Month == monthStart.Month).GroupBy(e => e.Date);

            /*var formattedDate = getMonth;
            oTxtDate.value = formattedDate.getMonth() + '/' +
                 (formattedDate.getMonth() + 1) + '/' + formattedDate.getFullYear();*/
            /*var events = Events?.GroupBy(e => e.Date);*/
            

            var html = new XDocument(
                new XElement("div",
                    new XAttribute("class", "container-fluid"),
                    new XElement("header",
                        new XElement("h4",
                            new XAttribute("class", "display-4 mb-2 text-center"),
                            monthStart.ToString("MMMM yyyy")
                        ),
                        new XElement("div",
                            new XAttribute("class", "row d-none d-lg-flex p-1 bg-dark text-white"),
                            Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Select(d =>
                                new XElement("h5",
                                    new XAttribute("class", "col-lg p-1 text-center"),
                                    d.ToString()
                                )
                            )
                        )
                    ),
                    new XElement("div",
                        new XAttribute("class", "row border border-right-0 border-bottom-0"),
                        GetDatesHtml()
                    )
                )
            );

            return html.ToString();

            IEnumerable<XElement> GetDatesHtml()
            {
                var startDate = monthStart.AddDays(-(int)monthStart.DayOfWeek);
                var dates = Enumerable.Range(0, 42).Select(i => startDate.AddDays(i));

                foreach (var d in dates)
                {
                    if (d.DayOfWeek == DayOfWeek.Sunday && d != startDate)
                    {
                        yield return new XElement("div",
                            new XAttribute("class", "w-100"),
                            String.Empty
                        );
                    }

                    var mutedClasses = "d-none d-lg-inline-block bg-light text-muted";
                    yield return new XElement("div",
                        new XAttribute("class", $"day col-lg p-2 border border-left-0 border-top-0 text-truncate {(d.Month != monthStart.Month ? mutedClasses : null)}"),
                        new XElement("h5",
                            new XAttribute("class", "row align-items-center"),
                            new XElement("span",
                                new XAttribute("class", "date col-1"),
                                d.Day
                            ),
                            new XElement("small",
                                new XAttribute("class", "col d-lg-none text-center text-muted"),
                                d.DayOfWeek.ToString()
                            ),
                            new XElement("span",
                                new XAttribute("class", "col-1"),
                                String.Empty
                            )
                        ),
                        GetEventHtml(d)
                    );
                }
            }

            IEnumerable<XElement> GetEventHtml(DateTime d)
            {
                return events?.SingleOrDefault(e => e.Key.Day == d.Day)?.Select(e =>
                    new XElement("a",
                        new XAttribute("class", $"event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small bg-{e.Type} text-white"),
                        new XAttribute("title", e.Title),
                        e.Title
                    )
                ) ?? new[] {
                new XElement("p",
                    new XAttribute("class", "d-lg-none"),
                    "No events"
                )
                };
            }
        }
    }
}
/*[HtmlTargetElement("calendar", TagStructure = TagStructure.NormalOrSelfClosing)]
public class CalendarTagHelper : TagHelper
{
    public int Month { get; set; }

    public int Year { get; set; }

    public List<CalendarEvent>? Events { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "section";
        output.Attributes.Add("class", "calendar");
        output.Content.SetHtmlContent(GetHtml());
        output.TagMode = TagMode.StartTagAndEndTag;
    }

    private string GetHtml()
    {
        var monthStart = new DateTime(Year, Month, 1);
        var events = Events?.GroupBy(e => e.Date);

        var html = new XDocument(
            new XElement("div",
                new XAttribute("class", "container-fluid"),
                new XElement("header",
                    new XElement("h4",
                        new XAttribute("class", "display-4 mb-2 text-center"),
                        monthStart.ToString("MMMM yyyy")
                    ),
                    new XElement("div",
                        new XAttribute("class", "row d-none d-lg-flex p-1 bg-dark text-white"),
                        Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Select(d =>
                            new XElement("h5",
                                new XAttribute("class", "col-lg p-1 text-center"),
                                d.ToString()
                            )
                        )
                    )
                ),
                new XElement("div",
                    new XAttribute("class", "row border border-right-0 border-bottom-0"),
                    GetDatesHtml()
                )
            )
        );

        return html.ToString();

        IEnumerable<XElement> GetDatesHtml()
        {
            var startDate = monthStart.AddDays(-(int)monthStart.DayOfWeek);
            var dates = Enumerable.Range(0, 42).Select(i => startDate.AddDays(i));

            foreach (var d in dates)
            {
                if (d.DayOfWeek == DayOfWeek.Sunday && d != startDate)
                {
                    yield return new XElement("div",
                        new XAttribute("class", "w-100"),
                        String.Empty
                    );
                }

                var mutedClasses = "d-none d-lg-inline-block bg-light text-muted";
                yield return new XElement("div",
                    new XAttribute("class", $"day col-lg p-2 border border-left-0 border-top-0 text-truncate {(d.Month != monthStart.Month ? mutedClasses : null)}"),
                    new XElement("h5",
                        new XAttribute("class", "row align-items-center"),
                        new XElement("span",
                            new XAttribute("class", "date col-1"),
                            d.Day
                        ),
                        new XElement("small",
                            new XAttribute("class", "col d-lg-none text-center text-muted"),
                            d.DayOfWeek.ToString()
                        ),
                        new XElement("span",
                            new XAttribute("class", "col-1"),
                            String.Empty
                        )
                    ),
                    GetEventHtml(d)
                );
            }
        }

        IEnumerable<XElement> GetEventHtml(DateTime d)
        {
            return events?.SingleOrDefault(e => e.Key == d)?.Select(e =>
                new XElement("a",
                    new XAttribute("class", $"event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small bg-{e.Type} text-white"),
                    new XAttribute("title", e.Title),
                    e.Title
                )
            ) ?? new[] {
            new XElement("p",
                new XAttribute("class", "d-lg-none"),
                "No events"
            )
            };
        }
    }
}
}
*/
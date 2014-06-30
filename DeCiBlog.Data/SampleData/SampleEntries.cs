using System;
using System.Collections.Generic;
using DeCiBlog.Model;

namespace DeCiBlog.Data.SampleData
{
    public class SampleEntries
    {
        public static List<BlogEntry> BlogEntries = new List<BlogEntry>
            {
                new BlogEntry
                {
                    Title = "Ich liebe MVC",
                    Text = "Ich liebe ASP.NET und möchte alles darüber lernen.",
                    CreationDate = new DateTime(2014,6,15),
                    Categories = new List<Category> {new Category {Name = "Web-Technologien"}},
                    Comments = new List<Comment>
                    {
                        new Comment {Created = new DateTime(2014, 6, 15), Text = "Ich mag MVC ebenfalls."},
                        new Comment {Created = new DateTime(2014, 6, 16), Text = "Ich auch"},
                        new Comment {Created = new DateTime(2014, 6, 17), Text = "Was für ein Mist!"}
                    },
                    Tags = "ASP.NET, MVC"
                },
                new BlogEntry
                {
                    Title = "C# ist super",
                    Text =
                        "Man sollte sich für eine Sprache entscheiden. Das sollte die Sprache sein, die man in allen Tiefen kennenlernt.",
                    CreationDate = new DateTime(2014,6,15),
                    Categories = new List<Category> {new Category {Name = "Programmiersprechen"}},
                    Comments = new List<Comment>
                    {
                        new Comment {Created = new DateTime(2014, 6, 15), Text = "So ist es!"},
                        new Comment {Created = new DateTime(2014, 6, 16), Text = "Sehe ich nicht so!"},
                        new Comment {Created = new DateTime(2014, 6, 17), Text = "Ich bin ein Programmier-Polyglot"}
                    },
                    Tags = "C#, Programmierung"
                },
                new BlogEntry
                {
                    Title = "Ich lerne jetzt JavaScript",
                    Text = "JavaScript ist wohl die am meisten unterschätzte Sprache.",
                    CreationDate = new DateTime(2014,6,15),
                    Categories = new List<Category> {new Category {Name = "Programmiersprechen"}},
                    Tags = "JavaScript, Programmierung"
                },
                new BlogEntry
                {
                    Title = "KnockoutJS ist auch Pflicht",
                    Text = "Clientseitige UI-Logik und Bidirektionale Datenbindung nur mit KnockoutJS :-)",
                    CreationDate = new DateTime(2014,6,15),
                    Categories = new List<Category> {new Category {Name = "Programmiersprechen"}},
                    Tags = "Frameworks"
                },
            };
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Site.Models
{
    public class SitemapNode
    {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes()
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = "http://www.esterganestam.se",
                    Priority = 1.00,
                    Frequency = SitemapFrequency.Weekly
                });

            nodes.Add(
                new SitemapNode()
                {
                    Url = "http://www.esterganestam.se/Home/Contact",
                    Priority = 0.95
                });

            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<SitemapNode> siteMapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode node in siteMapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(node.Url)),
                    node.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        node.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    node.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        node.Frequency.Value.ToString().ToLowerInvariant()),
                    node.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        node.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

    }

    public enum SitemapFrequency
    {
        Never,
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        Always
    }
}

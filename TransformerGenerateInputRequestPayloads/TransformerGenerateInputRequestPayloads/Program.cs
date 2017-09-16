using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument doc = XDocument.Load(@"C:\Users\rjjon\OneDrive\Dev work\TFNDecLodge TransformIn ATOTFND900003a.xml");

            if (doc != null)
            {
                Console.WriteLine("Document loaded...");

                XPathNavigator xPathNavigator = doc.CreateNavigator();
                xPathNavigator.MoveToFollowing(XPathNodeType.Element);
                IDictionary<string, string> namespaces = xPathNavigator.GetNamespacesInScope(XmlNamespaceScope.All);


                foreach (KeyValuePair<string, string> keyValuePair in namespaces.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"{keyValuePair.Key} ={keyValuePair.Value}");
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("New document");

            XDocument newDoc = new XDocument();
            XNamespace xbrli = "http://www.xbrl.org/2003/instance";
            XNamespace tfnd0002lodgereq0200 = "http://sbr.gov.au/rprt/ato/tfnd/tfnd.0002.lodge.request.02.00.report";
            XNamespace RprtPyType_02_10 = "http://sbr.gov.au/dims/RprtPyType.02.10.dims";
            XNamespace xbrldi = "http://xbrl.org/2006/xbrldi";
            XNamespace prsnunstrcnm1_02_01 = "http://sbr.gov.au/comnmdle/comnmdle.personunstructuredname1.02.00.module";
            XNamespace pyde_02_01 = "http://sbr.gov.au/icls/py/pyde/pyde.02.01.data";
            XNamespace pyde_02_00 = "http://sbr.gov.au/icls/py/pyde/pyde.02.00.data";
            XNamespace ogname1_02_00 = "http://sbr.gov.au/comnmdle/comnmdle.organisationname1.02.00.module";
            XElement rootElement = new XElement(xbrli +  "xbrl", 
                                new XAttribute(XNamespace.Xmlns+"xbrli", "http://www.xbrl.org/2003/instance"),
                                new XAttribute(XNamespace.Xmlns + "tfnd.0002.lodge.req.02.00", tfnd0002lodgereq0200),
                                new XAttribute(XNamespace.Xmlns + "xbrldi", xbrldi),
                                new XAttribute(XNamespace.Xmlns + "prsnunstrcnm1.02.01", prsnunstrcnm1_02_01),
                                new XAttribute(XNamespace.Xmlns + "pyde.02.01", pyde_02_01),
                                new XAttribute(XNamespace.Xmlns + "pyde.02.00", pyde_02_00),
                                new XAttribute(XNamespace.Xmlns + "orgname1.02.00", ogname1_02_00));

            XElement contextElement = new XElement(xbrli +"context", new XAttribute("id","RP"));
            XElement entityElement = new XElement(xbrli +"entity");
            XElement identifierElement = new XElement(xbrli +"identifier", new XAttribute("scheme", "http://www.ato.gov.au/wpn"), "00098745678");

            XElement segment = new XElement(xbrli +"segement");
            XElement explicitMember = new XElement(xbrldi +"explicitMember", new XAttribute("dimension", "RprtPyType.02.10:ReportPartyTypeDimension"), "RprtPyType_02_10:ReportingParty");


            XElement period = new XElement(xbrli+"period");
            period.Add( new XElement(xbrli +"startDate", DateTime.Now.ToString("yyyy-MM-dd")));
            period.Add(new XElement(xbrli + "endDate", DateTime.Now.ToString("yyyy-MM-dd")));

            segment.Add(explicitMember);
            identifierElement.Add(segment);
            entityElement.Add(identifierElement);
            contextElement.Add(entityElement);
            contextElement.Add(period);

            rootElement.Add(contextElement);

            rootElement.Add(new PersonUnstructuredName("RP", "Contact", "Mike Smith").ToXElement());
            rootElement.Add(new OrganisationNameDetails("RP", "MN", "Overseas Stars").ToXElement());
            newDoc.Add(rootElement);
            Console.WriteLine(newDoc);
        }
    }


    public class Context
    {
        public string Value { get; set; }

        public Context(string value)
        {
            this.Value = value;
        }
    }

    public class OrganisationNameDetails : Context
    {
        XNamespace pyde_02_00 = "http://sbr.gov.au/icls/py/pyde/pyde.02.00.data";
        private XNamespace ogname1_02_00 = "http://sbr.gov.au/comnmdle/comnmdle.organisationname1.02.00.module";
        public OrganisationNameDetails(string context, string code,  string name): base(context)
        {
            this.Code = code;
            this.Name = name;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public XElement ToXElement()
        {
            
            XElement organisationNameDetailsTuple = new XElement(ogname1_02_00+"OrganisationNameDetails");
            XElement  nameTypeCodeElement = new XElement(pyde_02_00 + "OrganisationNameDetails.OrganisationalNameType.Code", new XAttribute("contextRef", this.Value), Code);
            XElement nameElement = new XElement(pyde_02_00 + "OrganisationNameDetails.OrganisationalName.Text", new XAttribute("contextRef", this.Value), Name);

            organisationNameDetailsTuple.Add(nameTypeCodeElement);
            organisationNameDetailsTuple.Add(nameElement);

            return organisationNameDetailsTuple;
        }

    }


    public class PersonUnstructuredName : Context
    {
        public string UsageCode { get; set; }
        public string FullName { get; set; }


        public PersonUnstructuredName(string context, string usageCode, string fullName) : base(context)
        {
            this.Value = Value;
            this.FullName = fullName;
        }


        public XElement ToXElement()
        {
            XNamespace prsnunstrcnm1_02_01 = "http://sbr.gov.au/comnmdle/comnmdle.personunstructuredname1.02.00.module";
            XNamespace pyde_02_01 = "http://sbr.gov.au/icls/py/pyde/pyde.02.01.data";

            XElement personunstructuredName = new XElement(prsnunstrcnm1_02_01 + "PersonUnstructuredName");
            XElement personUsageCode = new XElement(pyde_02_01 + "PersonUnstructuredName.Usage.Code", new XAttribute("contextRef", Value), UsageCode);
            XElement fullName = new XElement(pyde_02_01 + "PersonUnstructuredName.FullName.Text", new XAttribute("contextRef", Value), FullName);

            personunstructuredName.Add(personUsageCode);
            personunstructuredName.Add(fullName);
            return personunstructuredName;
        }

    }
}

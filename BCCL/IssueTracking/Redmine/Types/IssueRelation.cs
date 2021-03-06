/*
   Copyright 2011 Dorin Huzum, Adrian Popescu.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BCCL.IssueTracking.Redmine.Types
{
    [Serializable]
    [XmlRoot("relation")]
    public class IssueRelation : Identifiable<IssueRelation>, IXmlSerializable, IEquatable<IssueRelation>
    {
        /// <summary>
        /// Gets or sets the issue id.
        /// </summary>
        /// <value>The issue id.</value>
        [XmlElement("issue_id")]
        public int IssueId { get; set; }

        /// <summary>
        /// Gets or sets the issue to id.
        /// </summary>
        /// <value>The issue to id.</value>
        [XmlElement("issue_to_id")]
        public int IssueToId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [XmlElement("relation_type")]
        public String Type { get; set; }

        /// <summary>
        /// Gets or sets the delay.
        /// </summary>
        /// <value>The delay.</value>
        [XmlElement("delay")]
        public int? Delay { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            while (!reader.EOF)
            {
                if (reader.IsEmptyElement && !reader.HasAttributes)
                {
                    reader.Read();
                    continue;
                }

                switch (reader.Name)
                {
                    case "id": Id = reader.ReadElementContentAsInt(); break;

                    case "issue_id": IssueId = reader.ReadElementContentAsInt(); break;

                    case "issue_to_id": IssueToId = reader.ReadElementContentAsInt(); break;

                    case "relation_type": Type = reader.ReadElementContentAsString(); break;

                    case "delay": Delay = reader.ReadElementContentAsNullableInt(); break;

                    default:
                        reader.Read();
                        break;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("issue_to_id", IssueToId.ToString());
            writer.WriteElementString("relation_type", Type);
            writer.WriteElementString("delay", Delay.ToString());
        }

        public bool Equals(IssueRelation other)
        {
            if (other == null) return false;
            return (Id == other.Id && IssueId == other.IssueId && IssueToId == other.IssueToId && Type == other.Type && Delay == other.Delay);
        }
    }
}
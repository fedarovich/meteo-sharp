using System;
using System.Collections.Generic;
using System.Linq;
using EnumsNET;
using MeteoSharp.Codes;

namespace MeteoSharp.Attibutes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = true)]
    public class CodeFormAttribute : FormatAttribute
    {
        public string CodeForm { get; }

        public string Name { get; }

        public IReadOnlyList<string> AlternativeNames { get; }

        public CodeForm StandardCodeForm { get; }

        public CodeFormAttribute(string codeForm, string name)
        {
            CodeForm = codeForm;
            Name = name;
            AlternativeNames = Array.Empty<string>();
        }

        public CodeFormAttribute(string codeForm, string name, params string[] alternativeNames)
        {
            CodeForm = codeForm;
            Name = name;
            AlternativeNames = alternativeNames;
        }

        public CodeFormAttribute(CodeForm standardCodeForm)
        {
            StandardCodeForm = standardCodeForm;
            var attributes = standardCodeForm.GetMember().Attributes.GetAll<CodeFormAttribute>().ToList();
            CodeForm = attributes[0].CodeForm;
            Name = attributes[0].Name;
            AlternativeNames = attributes.Skip(1).Select(x => x.Name).ToArray();
        }
    }
}

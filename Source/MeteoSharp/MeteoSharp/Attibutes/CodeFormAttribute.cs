using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MeteoSharp.Codes;

namespace MeteoSharp.Attibutes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = true)]
    public class CodeFormAttribute : Attribute
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
            var attributes =
                (from field in typeof(CodeForm).GetFields(BindingFlags.Public | BindingFlags.Static)
                let value = (CodeForm) field.GetValue(null)
                where value == standardCodeForm
                select field.GetCustomAttribute<CodeFormAttribute>()).ToList();

            CodeForm = attributes[0].CodeForm;
            Name = attributes[0].Name;
            AlternativeNames = attributes.Skip(1).Select(x => x.Name).ToArray();
        }
    }
}

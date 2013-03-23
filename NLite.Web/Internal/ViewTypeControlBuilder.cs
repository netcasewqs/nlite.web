using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.CodeDom;
using System.Collections;

namespace NLite.Web.Internal
{
    internal sealed class ViewTypeControlBuilder : ControlBuilder
    {
        private string _typeName;

        public override void Init(TemplateParser parser, ControlBuilder parentBuilder, Type type, string tagName, string id, IDictionary attribs)
        {
            base.Init(parser, parentBuilder, type, tagName, id, attribs);

            _typeName = (string)attribs["typename"];
        }

        public override void ProcessGeneratedCode(
            CodeCompileUnit codeCompileUnit,
            CodeTypeDeclaration baseType,
            CodeTypeDeclaration derivedType,
            CodeMemberMethod buildMethod,
            CodeMemberMethod dataBindingMethod)
        {
            derivedType.BaseTypes[0] = new CodeTypeReference(_typeName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SurveyGenerator.Core.Utilities
{
    [Serializable]
    public class SurveyGeneratorException:Exception
    {
        public SurveyGeneratorException()
        {
        }

        public SurveyGeneratorException(string message)
            : base(message)
        {
        }

        public SurveyGeneratorException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        protected SurveyGeneratorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public SurveyGeneratorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

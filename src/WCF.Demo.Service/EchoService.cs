using CoreWCF;
using System.Text.RegularExpressions;

namespace WCF.Demo.Service
{
    public class EchoService : IEchoService
    {
        public string Echo(string text)
        {
            Console.WriteLine($"Received '{text}' from client!");
            return text.ToUpper();
        }

        public string ComplexEcho(EchoMessage text)
        {
            Console.WriteLine($"Received {text.Text} from client!");
            var rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(text.Text.ToUpper().Trim(), "");
        }

        public string FailEcho(string text)
            => throw new FaultException<EchoFault>(new EchoFault() { Text = $"Could not process text '{text}'" }, new FaultReason("FailReason"));

    }
}

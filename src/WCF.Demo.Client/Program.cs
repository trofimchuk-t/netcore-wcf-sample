using ServiceReference1;
using System.ServiceModel;

// Instantiate the Service wrapper specifying the binding and optionally the Endpoint URL. The BasicHttpBinding could be used instead.
var client = new EchoServiceClient(EchoServiceClient.EndpointConfiguration.BasicHttpBinding_IEchoService1, "https://localhost:8443/EchoService/basichttp");
var input = "";

Console.WriteLine("Enter text to send text to EchoAsync() method:");
input = Console.ReadLine();
var simpleResult = await client.EchoAsync(input);
Console.WriteLine("Result: " + simpleResult);
Console.WriteLine();

Console.WriteLine("Enter text to send EchoMessage object:");
input = Console.ReadLine();
var msg = new EchoMessage() { Text = input };
var msgResult = await client.ComplexEchoAsync(msg);
Console.WriteLine("Result: " + msgResult);
Console.WriteLine();

try
{
    Console.WriteLine("Enter text to send to the FailEchoAsync() method:");
    input = Console.ReadLine();
    var faultResult = await client.FailEchoAsync(input);
    Console.WriteLine("Result: " + faultResult);
}
catch (FaultException<EchoFault> echoFaultException)
{
    Console.WriteLine("An error occured: " + echoFaultException.Message);
    Console.WriteLine("Details: " + echoFaultException.Detail.Text);
}
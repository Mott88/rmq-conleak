using Amqp;

var address = new Address($"amqp://username:{Uri.EscapeDataString("password")}@server:5672");
var con = new Connection(address);

while (true)
{
    var session = new Session(con);

    try
    {
        var receiver = new ReceiverLink(session, "myclient", "/amq/queue/thisqueuedoesnotexist");
        session.Close();
    }
    catch (Exception ex)
    {
        //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ex);
        session.Close();
    }
}
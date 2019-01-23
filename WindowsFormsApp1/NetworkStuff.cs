using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public class NetworkStuff
{
    private static NetworkStuff networkStuffSingleton;
    private WebRequest request = WebRequest.Create("http://localhost:3001/onichansInfo");

    public NetworkStuff()
    {
        Console.WriteLine("network sigleton created");
    }

    public static NetworkStuff getNetworkStuffSingleton()
    {
        if (networkStuffSingleton == null)
        {
            networkStuffSingleton = new NetworkStuff();
        }
        return networkStuffSingleton;
    }

    public async Task sendCardData(string[] data)
    {
        /*
        //declare type of request
        request.Method = "POST";
        //convert data to byte array
        byte[] byteArray = Encoding.UTF8.GetBytes(data[0] + ',' + data[1] + ',' + data[2]);
        //declate type of content sending
        request.ContentType = "application/x-www-form-urlencoded";
        //set lenght of the content
        request.ContentLength = byteArray.Length;

        Stream dataStream = request.GetRequestStream();

        dataStream.Write(byteArray, 0, byteArray.Length);

        dataStream.Close();

        WebResponse responce = request.GetResponse();
        //Display Status
        Console.WriteLine(((HttpWebResponse)responce).StatusDescription);

        dataStream = responce.GetResponseStream();

        StreamReader reader = new StreamReader(dataStream);

        string responseFromServer = reader.ReadToEnd();

        Console.WriteLine(responseFromServer);

        reader.Close();
        dataStream.Close();
        responce.Close();
        */

        HttpClient httpClient = new HttpClient();
        //return new Product { Name = result };
        HttpContent reqContent = new infoRequest();
        string requestContent = "{cardNumber:" + data[0] + ",expDate:" + data[1] + ",securityCode:" + data[2] + "}";
        await httpClient.PostAsync("http://localhost:3001/onichansInfo", reqContent);

        //return "ok"; //returns 200 for now since you probably cant fail outputing to the console
    }

    class infoRequest : HttpContent
    {
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            throw new NotImplementedException();
        }

        protected override bool TryComputeLength(out long length)
        {
            throw new NotImplementedException();
        }
    }

}

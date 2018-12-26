using System;
using System.IO;
using System.Net;
using System.Text;

public class NetworkStuff
{
    private static NetworkStuff networkStuffSingleton;
    private WebRequest request = WebRequest.Create("http://localhost:3001/musicians");

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

    public string sendCardData(string[] data)
    {
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

        return responseFromServer; //returns 200 for now since you probably cant fail outputing to the console
    }

}

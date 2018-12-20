using System;

public class NetworkStuff
{
    private static NetworkStuff networkStuffSingleton;

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

    public int sendCardData(string[] data)
    {
        Console.WriteLine(data[0] + ',' + data[1] + ',' + data[2]);
        System.Diagnostics.Debug.WriteLine(data[0] + ',' + data[1] + ',' + data[2]);
        return 200; //returns 200 for now since you probably cant fail outputing to the console
    }

}

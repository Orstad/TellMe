using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.MixedReality.WebRTC;

namespace PeerToPeerProgramm
{
    class Program
    {

        static async Task Main(string[] args)
        {
            try
            {
                var deviceList = await DeviceVideoTrackSource.GetCaptureDevicesAsync();

                foreach (var device in deviceList)
                {
                    Console.WriteLine($"Found webcam {device.name} (id: {device.id})");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var pc = new PeerConnection();

            var config = new PeerConnectionConfiguration
            {
                IceServers = new List<IceServer>
                {
                    new IceServer{Urls = {"stun:stun.l.google.com:19302"}}
                }
            };
            await pc.InitializeAsync(config);

            Console.ReadLine();
        }
    }
}

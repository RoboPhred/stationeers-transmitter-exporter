
using System;
using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Motherboards;
using Assets.Scripts.Objects.Pipes;
using BepInEx;
using UnityEngine;

namespace TransmitterExporter
{
    [BepInPlugin("net.robophreddev.stationeers.transmitterexporter", "Transmitter Exporter", "1.0.0.0")]
    public class ExamplePlugin : BaseUnityPlugin
    {
        void Awake()
        {
            Debug.Log("[Transmitter Exporter]: Hello World");
        }

        float elapsed = 0f;
        void Update()
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                CheckTransmitters();
            }
        }
        void CheckTransmitters()
        {
            foreach (var transmitter in Transmitters.AllTransmitters)
            {
                DumpTransmitter(transmitter);
            }
        }

        void DumpTransmitter(ILogicable transmitter)
        {
            Debug.Log(String.Format("Dumping transmitter: {0}", transmitter.DisplayName));
            foreach (LogicType logicType in Enum.GetValues(typeof(LogicType)))
            {
                if (transmitter.CanLogicRead(logicType))
                {
                    var value = transmitter.GetLogicValue(logicType);
                    Debug.Log(String.Format("== {0}: {1}", logicType, value));
                }
            }
        }
    }
}
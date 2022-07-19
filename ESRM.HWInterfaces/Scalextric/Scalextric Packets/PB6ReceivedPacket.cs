using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class PB6RecievedPacket
    {
        public HandsetTrackStatus HandsetTrackStatus { get; set; }
        public DriverPacket DrivePacket1 { get; set; }
        public DriverPacket DrivePacket2 { get; set; }
        public DriverPacket DrivePacket3 { get; set; }
        public DriverPacket DrivePacket4 { get; set; }
        public DriverPacket DrivePacket5 { get; set; }
        public DriverPacket DrivePacket6 { get; set; }
        public AuxPortCurrent AuxPortCurrent { get; set; }
        public CarIDTrackUpdate CarIDTrackUpdate { get; set; }
        public GameTime GameTime { get; set; }
        public ButtonStatus ButtonStatus { get; set; }
        public Checksum Checksum { get; set; }

        public PB6RecievedPacket(byte[] data)
        {
            HandsetTrackStatus = new HandsetTrackStatus(data[0]);
            DrivePacket1 = new DriverPacket(data[1]);
            DrivePacket2 = new DriverPacket(data[2]);
            DrivePacket3 = new DriverPacket(data[3]);
            DrivePacket4 = new DriverPacket(data[4]);
            DrivePacket5 = new DriverPacket(data[5]);
            DrivePacket6 = new DriverPacket(data[6]);
            AuxPortCurrent = new AuxPortCurrent(data[7]);
            CarIDTrackUpdate = new CarIDTrackUpdate(data[8]);
            byte[] gData = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                gData[i] = data[i + 9];
            }
            GameTime = new GameTime(gData);
            ButtonStatus = new ButtonStatus(data[13]);

            try
            {
                Checksum = new Checksum(data);
            }
            catch (Exception)
            {

            }
            
        }
    }
}

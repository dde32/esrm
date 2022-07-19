using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class PB6AuxPacket
    {
        public OperationMode OperationMode { get; set; }

        public DriverAuxPacket DrivePacket1 { get; set; }
        public DriverAuxPacket DrivePacket2 { get; set; }
        public DriverAuxPacket DrivePacket3 { get; set; }
        public DriverAuxPacket DrivePacket4 { get; set; }
        public DriverAuxPacket DrivePacket5 { get; set; }
        public DriverAuxPacket DrivePacket6 { get; set; }
        public LEDStatus LEDStatus { get; set; }

        public PB6AuxPacket()
        {
            OperationMode = new Scalextric.OperationMode(191);

            DrivePacket1 = new DriverAuxPacket();
            DrivePacket2 = new DriverAuxPacket();
            DrivePacket3 = new DriverAuxPacket();
            DrivePacket4 = new DriverAuxPacket();
            DrivePacket5 = new DriverAuxPacket();
            DrivePacket6 = new DriverAuxPacket();
            LEDStatus = new LEDStatus();
            LEDStatus.AuxData();
        }

        public byte[] ExportData()
        {
            byte[] result = new byte[9];
            result[0] = OperationMode.ToByte();
            result[1] = DrivePacket1.ToByte();
            result[2] = DrivePacket2.ToByte();
            result[3] = DrivePacket3.ToByte();
            result[4] = DrivePacket4.ToByte();
            result[5] = DrivePacket5.ToByte();
            result[6] = DrivePacket6.ToByte();
            result[7] = LEDStatus.ToByte();
            result[8] = Checksum.CalculateChecksum(result, 8);
            //convert ready to be sent
            return result;
        }
    }


    public class PB6NormalSendPacket
    {
        public OperationMode OperationMode { get; set; }
        public DriverPacket DrivePacket1 { get; set; }
        public DriverPacket DrivePacket2 { get; set; }
        public DriverPacket DrivePacket3 { get; set; }
        public DriverPacket DrivePacket4 { get; set; }
        public DriverPacket DrivePacket5 { get; set; }
        public DriverPacket DrivePacket6 { get; set; }
        public LEDStatus LEDStatus { get; set; }
 

        public PB6NormalSendPacket(byte[] data)
        {
            if (data.Length != 9)
                throw new Exception();
            OperationMode = new Scalextric.OperationMode(data[0]);
            DrivePacket1 = new DriverPacket(data[1]);
            DrivePacket2 = new DriverPacket(data[2]);
            DrivePacket3 = new DriverPacket(data[3]);
            DrivePacket4 = new DriverPacket(data[4]);
            DrivePacket5 = new DriverPacket(data[5]);
            DrivePacket6 = new DriverPacket(data[6]);
            LEDStatus = new LEDStatus(data[7]);
        }

        public PB6NormalSendPacket()
        {
            OperationMode = new OperationMode(0xff);
            DrivePacket1 = new DriverPacket();
            DrivePacket2 = new DriverPacket();
            DrivePacket3 = new DriverPacket();
            DrivePacket4 = new DriverPacket();
            DrivePacket5 = new DriverPacket();
            DrivePacket6 = new DriverPacket();
            LEDStatus = new LEDStatus();
        }

        public PB6NormalSendPacket(PB6RecievedPacket recievedPacket)
        {
            OperationMode = new OperationMode(0xff);
            DrivePacket1 = recievedPacket.DrivePacket1;
            DrivePacket2 = recievedPacket.DrivePacket2;
            DrivePacket3 = recievedPacket.DrivePacket3;
            DrivePacket4 = recievedPacket.DrivePacket4;
            DrivePacket5 = recievedPacket.DrivePacket5;
            DrivePacket6 = recievedPacket.DrivePacket6;
            LEDStatus = new LEDStatus(recievedPacket.HandsetTrackStatus.Handset1, recievedPacket.HandsetTrackStatus.Handset2, recievedPacket.HandsetTrackStatus.Handset3, recievedPacket.HandsetTrackStatus.Handset4, recievedPacket.HandsetTrackStatus.Handset5, recievedPacket.HandsetTrackStatus.Handset6,false,false);
        }

        public byte[] ExportData()
        {
            byte[] result = new byte[9];
            result[0] = OperationMode.ToByte();
            result[1] = DrivePacket1.ToByte();
            result[2] = DrivePacket2.ToByte();
            result[3] = DrivePacket3.ToByte();
            result[4] = DrivePacket4.ToByte();
            result[5] = DrivePacket5.ToByte();
            result[6] = DrivePacket6.ToByte();
            result[7] = LEDStatus.ToByte();
            result[8] = Checksum.CalculateChecksum(result,8);
            //convert ready to be sent
            return result;
        }
    }
}

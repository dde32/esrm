using System;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
	public class ButtonStatus
	{
		public bool StartPressed { get; set; }
		public bool RightPressed { get; set; }
		public bool UpPressed { get; set; }
		public bool EnterPressed { get; set; }
		public bool LeftPressed { get; set; }
		public bool DownPressed { get; set; }

		public ButtonStatus(byte data)
		{
			BitArray bData = new BitArray(new byte[] { data }).Not();
			if (bData.Count != 8)
				throw new Exception();
			StartPressed = bData[0];
			RightPressed = bData[1];
			UpPressed = bData[2];
			EnterPressed = bData[3];
			LeftPressed = bData[4];
			DownPressed = bData[5];
		}
	}
}

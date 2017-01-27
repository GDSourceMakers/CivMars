using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivMarsEngine.GUI
{
	public interface IGUI
	{
		//void TogelGui();

		void Open();

		void Close();

		int ClosingLevel();

	}
}
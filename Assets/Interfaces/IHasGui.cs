using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface IHasGui
{
	void TogelGui();

	void Open();

	void Close();

	int ClosingLevel();
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivMarsEngine
{
	public interface IGasTank
	{
		//GasTankCluster GetTankCluster();


		/// <summary>
		/// Returns the number of slots in the inventory.
		/// </summary>
		/// <returns></returns>
		int GetTankCount();

		/// <summary>
		/// Returns the name of the inventory
		/// </summary>
		/// <returns></returns>
		String GetGasInventoryName();

		/// <summary>
		/// Returns if the inventory is named
		/// </summary>
		/// <returns>True if named</returns>
		bool HasCustomGasInventoryName();

		/// <summary>
		/// Returns the Gas in slot i
		/// with amount
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		Gas GetGas(int index);


		/// <summary>
		/// Returns the max amount of gas in slot i
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		float GetMaxAmount(int index);

		/// <summary>
		/// Returns true if automation is allowed to insert the given Gas (ignoring stack size) into the given slot.
		/// </summary>
		/// <param name="slot">Number of the Tabk</param>
		/// <param name="givenItem">The Gas</param>
		/// <returns>True if allowed</returns>
		bool IsGasValidForSlot(int slot, Gas givenGas);

		//Do not make give this method the name canInteractWith because it clashes with Container
		bool IsUseableByPlayer(Player p);

		//Adds the Gas to the inventory returns the remained amount
		Gas AddGas(Gas i, int index);

		//Removes the Gas from the inventory returns the remained amount
		Gas RemoveGas(Gas i, int index);

		/// <summary>
		/// Transfers all the gas it can fit to a other tank
		/// </summary>
		/// <param name="ToInv">other tank to transfer to</param>
		/// <param name="index">other tank's index to transfer to</param>
		/// <param name="thisIndex">this inventorys index to transfer from</param>
		void TransferGas(IGasTank ToInv, int index, int thisIndex);

		/// <summary>
		/// Transfers a specific amount of a Gas from this inventory to a other
		/// </summary>
		/// <param name="Toinv">other tank to transfer to</param>
		/// <param name="toIndex">other tank's index to transfer to</param>
		/// <param name="thisIndex">this tank's index to transfer from</param>
		/// <param name="transferingAmount">amount to tramsfer</param>
		void TransferGasAmount(IGasTank ToInv, int toIndex, int thisIndex, int transferingAmount);
	}
}
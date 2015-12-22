using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivMarsEngine
{
	public interface IInventory
	{
		//Inventory GetInventory();


		/// <summary>
		/// Returns the number of slots in the inventory.
		/// </summary>
		/// <returns></returns>
		int GetInventorySize();

		/// <summary>
		/// Returns the name of the inventory
		/// </summary>
		/// <returns></returns>
		String GetInventoryName();

		/// <summary>
		/// Returns if the inventory is named
		/// </summary>
		/// <returns>True if named</returns>
		bool HasCustomInventoryName();

		/// <summary>
		/// Returns the item in slot i
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		Item GetStackInSlot(int i);

		/// <summary>
		/// Returns the maximum stack size for a inventory slot.
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		int GetInventoryStackLimit(int i);

		/// <summary>
		/// Returns true if automation is allowed to insert the given stack (ignoring stack size) into the given slot.
		/// </summary>
		/// <param name="slot">Number of the slot</param>
		/// <param name="givenItem">The item</param>
		/// <returns>True if allowed</returns>
		bool IsItemValidForSlot(int slot, Item givenItem);

		//Do not make give this method the name canInteractWith because it clashes with Container
		bool IsUseableByPlayer(Player p_70300_1_);

		//Adds the item to the inventory returns the remained amount
		Item Add(Item i);

		//Removes the item to the inventory returns the remained amount
		Item Remove(Item i);

		/// <summary>
		/// Transfers a item from this inventory to a other
		/// </summary>
		/// <param name="ToInv">other inv to transfer to</param>
		/// <param name="index">this inventorys index to transfer</param>
		void TransferItem(IInventory ToInv, int index);

		/// <summary>
		/// Transfers a specific amount of a item from this inventory to a other
		/// </summary>
		/// <param name="Toinv">other inv to transfer to</param>
		/// <param name="fromindex">this inventorys index to transfer</param>
		/// <param name="transferingAmount">amount to tramsfer</param>
		void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount);
	}
}
using System;

namespace EMS.Core.Helpers
{
    // Summary:
    //     Gets the state of a object.
    [Flags]
    public enum EntityState
    {
        // Summary:
        //     The row has been created but is not part of any ItemCollection.
        //     A System.Data.DataRow is in this state immediately after it has been created
        //     and before it is added to a collection, or if it has been removed from a
        //     collection.
        Detached = 1,
        //
        // Summary:
        //     The row has not changed since Item.AcceptChanges() was last
        //     called.
        Unchanged = 2,
        //
        // Summary:
        //     The row has been added to a ItemCollection, and Item.AcceptChanges()
        //     has not been called.
        Added = 3,
        //
        // Summary:
        //     The row was deleted using the Item.Delete() method of the
        //     Item.
        Deleted = 4,
        //
        // Summary:
        //     The row has been modified and Item.AcceptChanges() has not
        //     been called.
        Modified = 5
    }
}
/***********************************************************************
 * Module:  Equipment.cs
 * Purpose: Definition of the Class Equipment
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Equipment
   {
      public Equipment MoveEquipment(int roomId, Equipment equipment)
      {
         // TODO: implement
         return null;
      }
      
      public Equipment AddEquipment(Equipment newEquipment)
      {
         // TODO: implement
         return null;
      }
      
      public List<Equipment>[] EquipmentQuantity()
      {
         // TODO: implement
         return null;
      }
   
      public Manager[] manager;
   
      private int Id;
      private EquipmentType Type;
      private int Quantity;
      private String Name;
      private Rooms Room;
   
   }
}
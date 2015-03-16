// ListGroupCollection.cs

// Copyright (C) 2015 Curtis Knapp

// This program is free software; you can redistribute it and/or modify it under the terms of the GNU 
// General Public License as published by the Free Software Foundation; either version 2 of the 
// License, or (at your option) any later version.

// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without 
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See 
// the GNU General Public License for more details. You should have received a copy of the GNU 
// General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Twitter.Web.Controls
{
    public class ListGroupCollection : CollectionBase
    {
        protected ListGroup Parent = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListGroupCollection" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public ListGroupCollection(ListGroup parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// Indexer property for the collection that returns and sets an item
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public ListGroupItem this[int index]
        {
            get { return (ListGroupItem)List[index]; }
            set { List[index] = value; }
        }

        /// <summary>
        /// Adds the specified list group item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(ListGroupItem item)
        {
            List.Add(item);
            Parent.Controls.Add(item);
        }

        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void Insert(int index, ListGroupItem item)
        {
            List.Insert(index, item);
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Remove(ListGroupItem item)
        {
            List.Remove(item);
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(ListGroupItem item)
        {
            return List.Contains(item);
        }

        /// <summary>
        /// Index the of item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public int IndexOf(ListGroupItem item)
        {
            return List.IndexOf(item);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        public void CopyTo(ListGroupItem[] array, int index)
        {
            List.CopyTo(array, index);
        }
    }
}

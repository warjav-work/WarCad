using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCad.Entities
{
    public abstract class EntityObject : ICloneable
    {
        private readonly EntityType type;
        protected bool isVisible;
        protected bool selected;

        protected EntityObject(EntityType type)
        {
            this.type = type;
            this.isVisible = true;
            this.selected = false;
        }

        public EntityType Type 
        { 
            get { return this.type; } 
        }

        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        public bool IsSelected
        {
            get { return this.selected; }
        }

        public void Select()
        {
            this.selected = true;
        }

        public void DeSelect()
        {
            this.selected = false;
        }

        public abstract object Clone();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

[System.Serializable]
public class TileSetAndPlayerEvent : UnityEvent<TileSet,Player>
{
}

using UnityEngine;
using System.Collections;
using Player.Events;

public class PlayerBroadcast : MonoBehaviour {

	private int playerID = 0;
	private int characterID = 0;
	
	public void BroadCastMyPlayer () {
		InteractionEvents.BroadcastPlayer (this.playerID, this.characterID);
	}
}

namespace Player.Events {
	partial class InteractionEvents {
		
		public delegate void SimpleInfoEvent(int playerID, int characterID);
		private static SimpleInfoEvent OnBroadcastPlayerDelegate;
		public static event SimpleInfoEvent OnBroadcastPlayer {
			add {
				OnBroadcastPlayerDelegate -= value;
				OnBroadcastPlayerDelegate += value;
			} remove {
				OnBroadcastPlayerDelegate -= value;
			}
		}
		public static void BroadcastPlayer(int playerID, int characterID) {
			if(OnBroadcastPlayerDelegate != null) {
				OnBroadcastPlayerDelegate(playerID, characterID);
			}
		}
	}
}

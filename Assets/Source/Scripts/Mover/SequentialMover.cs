using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WIP: this class is not yet complete.  Not ready for use.
public class SequentialMover : Mover {
	// Keeps sequentially alternating between which mover in the list gets applied...
	public Mover[] moverList; // List of Movers.
	int moverIdx;
	
	// ...repeats numRepetitions times.
	public int numRepetitions = -1; // Num repetitions before quitting, or -1 to loop endlessly.
	int repetitionNo;
	
	bool isDone = false;

	public override void Move() {
		moverList[moverIdx].Move();
		if (moverList[moverIdx].IsDone()) {
			moverIdx++;
			
			if (moverIdx > moverList.Length) {
				repetitionNo++;
				moverIdx = 0;
				
				if (numRepetitions > 0 && repetitionNo >= numRepetitions )
					isDone = true;
			}
		}
	}

	public override bool IsDone() {
		return isDone;
	}
}

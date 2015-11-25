using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TreeSharpPlus;

public class MyBehaviorTree : MonoBehaviour
{
	public Transform wander1;
	public Transform wander2;
	public Transform wander3;
	public Transform wander4;
	public Transform wander5;

	public GameObject Daniel1;
	public GameObject Daniel2;
	public GameObject Daniel3;

	public GameObject InteractionManA;
	public GameObject InteractionManB;

	private GameObject[] GameCharacters;
	private BehaviorAgent behaviorAgent;

	// Use this for initialization
	void Start ()
	{
		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	protected Node ST_ApproachAndWait(GameObject GameCharacter, Transform target)
	{
		Val<Vector3> position = Val.V (() => target.position);
		return new Sequence( GameCharacter.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(500));
	}

	protected Node IdleFight(GameObject GameCharacter) {
		BehaviorMecanim behavior = GameCharacter.GetComponent<BehaviorMecanim> ();
		//BehaviorMecanim behaviorhands = GameCharacter.GetComponent<Node_HandAnimation> ();
		return new Sequence (
			behavior.Node_BodyAnimation("BREAKDANCE", true),
			behavior.Node_BodyAnimation("BREAKDANCE", false)
			//behavior.Node_HandAnimation("H_CowBoy", false)
			);
	} 


	protected Node Converse(GameObject a) {
		BehaviorMecanim behavior1 = a.GetComponent<BehaviorMecanim> ();
		//BehaviorMecanim behaviorhands = GameCharacter.GetComponent<Node_HandAnimation> ();
		return new Sequence (behavior1.Node_BodyAnimation("B_Dying", true), behavior1.Node_BodyAnimation("B_Dying", false));
	}


	protected Node ST_Gesture(string name, bool s)
	{
		        Val<string> Gesture_name = Val.V(() => name);
		        Val<bool> start = Val.V(() => s);
				return InteractionManA.GetComponent<BehaviorMecanim>().Node_BodyAnimation(Gesture_name, start);
    }

	protected Node ST_Gestures_Hand(GameObject P, string name, long time)
	    {
		        Val<string> Gesture_name = Val.V(() => name);
		        Val<bool> start = Val.V(() => true);
		        return new Sequence(P.GetComponent<BehaviorMecanim>().Node_HandAnimation(Gesture_name, start),
		                                                         new LeafWait(time),
		                                                       P.GetComponent<BehaviorMecanim>().Node_HandAnimation(Gesture_name, false));
		   }



	protected Node FireBreath(GameObject GameCharacter) {
		BehaviorMecanim behavior = GameCharacter.GetComponent<BehaviorMecanim> ();
		return new Sequence (behavior.Node_FaceAnimation("F_FireBreath", true), behavior.Node_BodyAnimation("F_FireBreath", false));
	} 



/*	protected Node Dance(GameObject GameCharacter) {
		BehaviorMecanim behavior = GameCharacter.GetComponent<BehaviorMecanim> ();
		return new Sequence (behavior.Node_Dance (), behavior.Node_StopDance ());
		//return new Sequence (behavior.
	} */


/*
	protected Node ScaryCreepy(GameObject GameCharacter) {
		BehaviorMecanim behavior = GameCharacter.GetComponent<BehaviorMecanim> ();
		return behavior.Node_ScaryCreepy ();
	} */
	protected Node LookAt(GameObject from, GameObject to) {
		BehaviorMecanim behavior = from.GetComponent<BehaviorMecanim> ();
		return behavior.Node_OrientTowards (to.transform.position + new Vector3(0,2,0));
	} 
	
	protected Node BuildTreeRoot()
	{
		int numberwand = 0;
	/*
	return
			new DecoratorLoop(
				new SequenceShuffle(
					this.ST_ApproachAndWait(this.wander1),
					this.ST_ApproachAndWait(this.wander2),
					this.ST_ApproachAndWait(this.wander3)));

		 */


		return
		//	new DecoratorLoop(
				new SequenceShuffle(
				this.ST_ApproachAndWait (InteractionManB, this.wander2),
				this.ST_ApproachAndWait (InteractionManA, this.wander3),
				this.ST_ApproachAndWait (Daniel2, this.wander4),
				
				this.ST_ApproachAndWait(Daniel3, this.wander1),
				this.IdleFight(Daniel3),

				this.ST_Gesture("BreakDance", true),
				this.ST_Gesture("BreakDance", false),

				this.ST_ApproachAndWait (Daniel1, this.wander1),
				

				this.IdleFight (Daniel1),
				
				this.ST_ApproachAndWait (Daniel1, this.wander5),
				this.ST_ApproachAndWait (Daniel1, this.wander1),
				
				this.IdleFight(Daniel2),
				
				this.ST_ApproachAndWait (Daniel1, this.wander4),
				this.ST_ApproachAndWait (InteractionManB, this.wander1),
				this.ST_ApproachAndWait (Daniel2, this.wander5),
				
				this.ST_Gestures_Hand (Daniel1, "SATNIGHTFEVER", 5000),
				this.ST_Gestures_Hand (InteractionManB, "SATNIGHTFEVER", 2000),
				this.ST_Gestures_Hand (Daniel2, "SATNIGHTFEVER", 3000),
				
				this.ST_ApproachAndWait (Daniel2, this.wander1),
				this.IdleFight (Daniel2),
				
				this.ST_Gestures_Hand (InteractionManA, "SATNIGHTFEVER", 1000),
				this.ST_ApproachAndWait (Daniel1, this.wander2),
				this.ST_ApproachAndWait (Daniel2, this.wander2),
				
				this.LookAt (Daniel1, Daniel2),
				this.LookAt (Daniel2, Daniel1),
				
				this.ST_ApproachAndWait (Daniel2, this.wander3),
				this.ST_ApproachAndWait (InteractionManA, this.wander2),
				this.ST_ApproachAndWait (InteractionManB, this.wander2),
				this.ST_ApproachAndWait (InteractionManA, this.wander3),
				this.ST_ApproachAndWait (InteractionManB, this.wander1),


	
				this.ST_Gestures_Hand (InteractionManB, "SATNIGHTFEVER", 2000),
				this.ST_Gestures_Hand (Daniel2, "SATNIGHTFEVER", 3000)

		//	)	
				);



		Sequence DanceOff = new Sequence(
		new DecoratorLoop (
				new SequenceShuffle (

			this.ST_ApproachAndWait (InteractionManB, this.wander2),
			this.ST_ApproachAndWait (InteractionManA, this.wander3),
			this.ST_ApproachAndWait (Daniel2, this.wander4),

			this.ST_ApproachAndWait(Daniel3, this.wander1),
			this.IdleFight(Daniel3),
			this.ST_Gesture("BreakDance", true),

			this.ST_ApproachAndWait (Daniel1, this.wander1),
		
			this.ST_Gesture("BreakDance", false),
			this.IdleFight (Daniel1),

			this.ST_ApproachAndWait (Daniel1, this.wander5),
			this.ST_ApproachAndWait (Daniel1, this.wander1),

			this.IdleFight(Daniel2),

			this.ST_ApproachAndWait (Daniel1, this.wander4),
			this.ST_ApproachAndWait (InteractionManB, this.wander1),
			this.ST_ApproachAndWait (Daniel2, this.wander5),

			this.ST_Gestures_Hand (Daniel1, "SATNIGHTFEVER", 5000),
			this.ST_Gestures_Hand (InteractionManB, "SATNIGHTFEVER", 2000),
			this.ST_Gestures_Hand (Daniel2, "SATNIGHTFEVER", 3000),

			this.ST_ApproachAndWait (Daniel2, this.wander1),
			this.IdleFight (Daniel2),

			this.ST_Gestures_Hand (InteractionManA, "SATNIGHTFEVER", 1000),
			this.ST_ApproachAndWait (Daniel1, this.wander2),
			this.ST_ApproachAndWait (Daniel2, this.wander2),

			this.LookAt (Daniel1, Daniel2),
			this.LookAt (Daniel2, Daniel1),

			this.ST_ApproachAndWait (Daniel2, this.wander3),
			this.ST_ApproachAndWait (InteractionManA, this.wander2),
			this.ST_ApproachAndWait (InteractionManB, this.wander2),
			this.ST_ApproachAndWait (InteractionManA, this.wander3),
			this.ST_ApproachAndWait (InteractionManB, this.wander1),

			this.ST_Gestures_Hand (InteractionManB, "SATNIGHTFEVER", 2000),
			this.ST_Gestures_Hand (Daniel2, "SATNIGHTFEVER", 3000))


		) 
			);
			return DanceOff; 
	
}
}

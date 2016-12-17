private var motor : CharacterMotor;
var xDirection : int;
var yDirection : int;

var forward : KeyCode;
var backward : KeyCode;
var left : KeyCode;
var right : KeyCode;
var rememberer : GameObject;
var jump : KeyCode;

// Use this for initialization
function Awake () {

	rememberer = GameObject.FindGameObjectWithTag("rememberer");

	forward = rememberer.GetComponent("rememberer").moveForwards;
		left = rememberer.GetComponent("rememberer").moveLeft;
		right = rememberer.GetComponent("rememberer").moveRight;
		backward = rememberer.GetComponent("rememberer").moveBackwards;
		jump = rememberer.GetComponent("rememberer").jump;
	
	motor = GetComponent(CharacterMotor);
}

// Update is called once per frame
function Update () {

	if (Input.GetKey(forward)) {
		yDirection = 1;
	}
	
	if (Input.GetKeyUp(forward)) {
	yDirection = 0;
	}
	
	if (Input.GetKey(backward)) {
		yDirection = -1;
	}
	
	if (Input.GetKeyUp(backward)) {
	yDirection = 0;
	}
	
	if (Input.GetKey(left)) {
		xDirection = -1;
	}
	
	if (Input.GetKeyUp(left)) {
	xDirection = 0;
	}
	
	if (Input.GetKey(right)) {
		xDirection = 1;
	}
	
	if (Input.GetKeyUp(right)) {
	xDirection = 0;
	}
	
	
	// Get the input vector from kayboard or analog stick
	var directionVector = new Vector3(xDirection, 0, yDirection);
	
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetKey(jump);
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")

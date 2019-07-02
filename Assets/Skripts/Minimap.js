var player : Transform;

function Start () {
}

function Update () {
}

//lateUpdate wird erst nach der Update-Funktion ausgeführt
function LateUpdate(){
	transform.position = Vector3 (player.position.x, player.position.y + 10, player.position.z);
}
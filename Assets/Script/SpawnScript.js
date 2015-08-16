#pragma strict


	public var enemy : GameObject;
	public var spawnTime : float = 2;
	
	function Start () {
		InvokeRepeating ("addEnemy", spawnTime, spawnTime);
	}

	function addEnemy() {
		var x1 = transform.position.x - GetComponent.<Renderer>().bounds.size.x / 2;
		var x2 = transform.position.x + GetComponent.<Renderer>().bounds.size.x / 2;

		var spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
	
    // Create an enemy at the 'spawnPoint' position
    Instantiate(enemy, spawnPoint, Quaternion.identity);
}




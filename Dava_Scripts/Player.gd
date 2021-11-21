extends KinematicBody2D

var speed = 15
var jumpForce = 400
var gravity = 400

var vel = Vector2()

#onready var imagePlayer = get_node("player")

func _physics_process(_delta):
	if Input.is_action_pressed("left"):
		vel.x -= speed
	elif Input.is_action_pressed("right"):
		vel.x += speed
	
	#vel.y += gravity * delta
	
	#if Input.is_action_pressed("jump") and is_on_floor():
		#vel.y -= jumpForce
		
	vel = move_and_slide(vel, Vector2.UP)
	
	#if vel.x < 0:
		#imagePlayer.flip_h = true
	#elif vel.x > 0:
		#imagePlayer.flip_h = false
	

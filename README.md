# SaiGameC3
## Start 2/2/2025: 
*Hành trình học 100 tập toturial c3 trên kênh saigame*
## Run 6/2: 
- E0 -> E14:
	- Thay vì singleton cơ bản như trong clip, thì mình áp dụng genetic class cho singleton luôn, áp dụng được mọi nơi
	- Mọi thứ vẫn ổn
## 7/2
- E14 ->:
	- Hôm nay gặp 1 lỗi khá thú vị và đã fix được
		- Spawner mình cho kế thừa từ singleton genetic class
		- JunkSpawner + BulletSpawner kế thừa từ Spawner, tuy nhiên khi run, 1 cái sẽ bị hủy do tính chất singleton
		- giải pháp: biến spawner thành 1 genetic class luôn
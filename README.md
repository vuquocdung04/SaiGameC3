# SaiGameC3
## Start 2/2/2025: 
*Hành trình học 100 tập toturial c3 trên kênh saigame*
## Run 6/2: 
- E0 -> E14:
	- Thay vì singleton cơ bản như trong clip, thì mình áp dụng genetic class cho singleton luôn, áp dụng được mọi nơi
	- Mọi thứ vẫn ổn
## 7/2:
- E14 -> E18:
	- Hôm nay gặp 1 lỗi khá thú vị và đã fix được
		- Spawner mình cho kế thừa từ singleton genetic class
		- JunkSpawner + BulletSpawner kế thừa từ Spawner, tuy nhiên khi run, 1 cái sẽ bị hủy do tính chất singleton
		- giải pháp: biến spawner thành 1 genetic class luôn
	- Pooling a sai có vấn đề:
		- bản chất giống, thay vì destroy đi thì setActive nó để tái sử dụng
		- tuy nhiên những cái nào sử dụng được thì lại add vào list và khi lấy ra thì xóa khỏi list. Dẫn tới ảnh hưởng tới hiệu năng vì nó cứ add và remove list liên tục
## 8/2:
- E19 ->

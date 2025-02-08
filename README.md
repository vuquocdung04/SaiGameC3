# SaiGameC3
## Start 2/2/2025: 
*Hành trình học 100 tập toturial c3 trên kênh saigame*
## Run 6/2: 
- E0 -> E14:
	- Thay vì singleton cơ bản như trong clip, thì mình áp dụng genetic class cho singleton luôn, áp dụng được mọi nơi
	- Mọi thứ vẫn ổn
## 7/2:
- E14 -> E18:
	- 🟢Hôm nay gặp 1 lỗi khá thú vị và đã fix được
		- Spawner mình cho kế thừa từ singleton genetic class
		- JunkSpawner + BulletSpawner kế thừa từ Spawner, tuy nhiên khi run, 1 cái sẽ bị hủy do tính chất singleton
		- giải pháp: biến spawner thành 1 genetic class luôn
	- 🟢Pooling a sai có vấn đề:
		- bản chất giống, thay vì destroy đi thì setActive nó để tái sử dụng
		- tuy nhiên những cái nào sử dụng được thì lại add vào list và khi lấy ra thì xóa khỏi list. Dẫn tới ảnh hưởng tới hiệu năng vì nó cứ add và remove list liên tục
## 8/2:
- E19 -> E33:
	- 🟢E21: học về cách xoay thiên thạch (vật thể), tuy nhiên tại sao:
		- transform.eulerAngel = new Vector3(0,0,1)
		- transform.rotation = Quaternion.Euler(0,0,1)
		- 2 cái trên giống nhau mà, đều quay góc => dùng Quaternion sẽ tránh được tình trạng *"Gimbal Lock"*
	- 🟢Vậy thì *"Gimbal Lock"* là cái gì:
		- Trong Unity (và hầu hết các hệ tọa độ 3D), một vật thể có ba trục:
            - X (Pitch - Ngửa/Nhìn xuống)
            - Y (Yaw - Quay trái/phải)
            - Z (Roll - Lật ngang trái/phải)
        - 🟢Cách dễ hiểu nhất: dùng điện thoại
            - Cầm điện thoại theo hướng bình thường (màn hình đối diện bạn).
            - Xoay nó lên 90° sao cho màn hình chỉ lên trời.
            - Bây giờ thử xoay sang trái/phải (theo trục Y ban đầu).
            - 👉 Bạn sẽ thấy nó giống như đang quay theo trục Z!
            - Khi đó, xoay theo Y không còn hoạt động độc lập nữa, vì nó bị gộp chung với Z.
	- 🟢E22:  truyền nhận damage sẽ cấu trúc theo kiểu
		- **DamageSender**: Gửi damage
		- **DamageReceier**: Nhận damage
		- **BulletImpart**: check trigger + quản lí collider + rigidbody
		- **BulletCtrl**: sẽ quản lí damagesender, tránh các script khác gọi thẳng tới nó, mà phải gọi thông qua BulletCtrl
		- **BulletAbstract**: sẽ quản lí BulletCtrl, để khi thằng những thằng con muốn gọi tới thằng cha là: BulletCtrl thì phải kế thừa từ BulletAbstract
		- 👉Vậy thì tại sao phải phức tạp thế, sao không singleton BulletCtrl luôn, hoặc trong thằng con thì Gọi đến LoadBulletCtrl ?
		- 👉 Cấu trúc này sau để dùng observer, hiểu để tại sao observer làm code trông đỡ bị ràng buộc hơn
	- 🟢E23: kiểm soát số lượng junk spawn
	- 🟢Trong folder code lúc này có:
		- Spawner
		- JunkSpawner
		- JunkSpawnerCtrl
		- JunkSpawnerRamdom
		- JunkSpawnerPoints
	- 👉 cấu trúc nó sẽ như thế này:
		- Spawner: kiểm soát spawn, despawn => để pooling
		- JunkSpawner: là đại diện spawner cho vũ trụ Junk =))
		- Thì từ giờ các JunkSpawnerCtrl, JunkSpawnerRamdom, JunkSpawnerPoints nếu cần sẽ gọi tới thằng JunkSpawner thay vì gọi trực tiếp tới Spawner
		- 👉 Hiểu đơn giản: JunkSpawner: Chính là Bản sao của Spawner ( thật ra là con của nó)
	- 🟢E25: thay vì truyền string để ramdom junk => dùng chính số thứ tự trong list để gọi
	- 🟢E26: folder **Resources**
		- Unity sẽ đọc file từ ổ đĩa và load vào Ram nếu vứt Resources ở mấy hàm start, update, onEnable,...
		-  👉 Resources nên được lưu các thành phần nhỏ như scripttableobj nhỏ,...
		-  👉 dùng AddressAble Tải asset động, tối ưu RAM, hỗ trợ cập nhật online
	- 🟢E32: cơ bản rơi vật phẩm
		- **ItemCode**: quản lí enum tên item rơi
		- **ItemSO**: là scriptableobj quản lí enum(Itemcode)
		- **DropRate**: quản lí ItemSO, tỉ lệ rơi đồ
		- **ItemDropSpawner**: singleton, quản lí list DropRate 
	- 🤔 cấu trúc code hơi dở vì:
		- tên các enum == tên gameobj ở hirachie thì nó mới spawn được
		- vì ở script Spawn method: GetPrefabname nó load các thằng con đồng thời lấy chính tên của cno luôn
		
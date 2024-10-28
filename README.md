# SpartaSurvival
이름을 SpartaSurvival로 지었으나 JumpMap만 구현됨

#### 키 가이드
- WASD : 전후좌우 움직임
- Space : 점프 (눌렀다가 뗐을 때 점프 발동), 누르고 있는 시간에 따라 점프 높이가 달라진다.   
최대 0.5초까지 누르고 있다가 떼면 1.5배 높이 점프((1 + 누른 시간) * 점프 파워)
- Left Ctrl : 활공. 공중에서 누르고 있으면 천천히 떨어진다.
- tab : 인벤토리
- E : 상호작용 키. 게임에 존재하는 상호작용 가능한 오브젝트를 E를 눌러 각각의 기능을 활성화 한다.
- Mouse Left button : 공격
- C : Switching camera view 1인칭 / 3인칭

#### 구현 기능
- (필수) 기본 이동 및 점프 : 점프의 경우 누른 시간에 따라 점프 높이가 달라지게 구현
- (필수) 체력바 UI & (도전) 추가 UI: 체력, 스테미나, 배고픔 UI 설정. 점프나 활공 시 스테미나 소모
- (필수) 동적 환경 조사 : Item, Util Object의 정보 UI 표시
- (필수) 점프대
- (필수) 아이템 데이터 : 검, 도끼, 그래플링 화살, 버섯, 스테이크, 당근, 나무
- (필수) 아이템 사용 : 버섯, 스테이크 사용(섭취) 시 플레이어의 scale과 mass가 변한다.
- (도전) 3인칭 시점 : C 키를 누르면 1인칭-3인칭 전환
- (도전) 움직이는 플랫폼 : WoodBoat위에서 E를 누르면 출발 목표 위치에 도달하면 5초간 멈추고 처음 위치로 돌아간다.
- (도전) 상호작용 가능한 오브젝트 표시 : Interactable Layer를 갖는 Item/Util Object의 설명이 뜨고, Util Object의 경우 상호작용 시 수행하는 기능 설명이 나온다.
- (도전) 플랫폼 발사기 : E를 누르면 위로 발사

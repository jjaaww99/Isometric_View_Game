# Isometric_View_Game
유니티 팀 프로젝트

## 🖥️프로젝트 소개
디아블로를 참고하여 만든 디아블로 모작 게임입니다.

## 🕰️개요
개발기간 : 24년 5월 13일 ~ 24년 6월 19일

개발 엔진 및 언어 : Unity & C#

Unity 버전: 2020.3.19f1
jira 링크 : (https://jjaaww99.atlassian.net/jira/software/projects/KAN/boards/1/timeline?shared=&atlOrigin=eyJpIjoiODUwYTg0MDZlMGExNDBjYWFmNGFlZjQ5ZjNjZjAyY2YiLCJwIjoiaiJ9)

### 🧑‍🤝‍🧑맴버구성
-김장원 - 플레이어,

-고영민 - 몬스터,

-김용건 - 맵,

### 📌게임진행 방식

플레이어가 죽을때까지 몬스터와 전투를 하다가 사망시 게임이 종료되고 재입장하거나 스코어보드에서 점수 확인

startscene으로 게임을 시작 → ymproto에서 게임 작동 → scorescene에서 점수 확인 및 재도전,종료 선택

### ⚙️주요 기능

**플레이어 작동 방식**

마우스 우클릭으로 캐릭터 이동,기본공격

자원(분노)을 소모해서 스킬 사용

자원은 몬스터에게 기본공격시 획득가능, 레벨에 따른 플레이어의 스탯 증가

마우스 우클릭 : 이동 또는 공격
Q : 지면 강타
W : 휠윈드

**몬스터 ai**

생성시 2초뒤 배회하고 플레이어가 감지 되면 플레이어에게 달려가 공격
체력이 0이되면 사망하고 경험치와 골드를 제공

**맵**

사냥에만 집중할 수 있도록 좁은 길목과 넓은 지역을 번갈아 둠

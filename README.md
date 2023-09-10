## 개요

---

게임(프로젝트) 이름: 공대 탈출 일지

기간: 2023.06.25~ 

개발 엔진 및 언어: Unity(2021.3.25f1) & C# 

팀(멤버): 이런 게 게임?? (팀장: 유재림, 고승민, 이도엽, 이승미)

→개발 동기 게임설명 첫번째 이미지 전에다 적을게

## 게임설명

---

![시작 스토리 진행](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/%25EC%25B9%25BC%25EB%25A0%2588%25EC%259D%25B4%25EB%258F%2584_intro.png)

시작 스토리 진행

![게임 시작 화면](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/%25EC%25B9%25BC%25EB%25A0%2588%25EC%259D%25B4%25EB%258F%2584_roby.png)

게임 시작 화면

"공대 탈출 일지"는 학교를 배경으로 평소 학교 생활 중 느끼는 탈출 욕구를 해소하고자 개발되었습니다. 이 게임은 친숙한 학교 공간과 괴담을 창의적으로 결합하여 플레이어의 호기심을 자극하며, 함정과 몬스터에 대한 긴장감을 통해 감정적으로 강렬한 경험을 제공합니다. 이를 통해 플레이어는 학교 생활을 다양한 시각에서 탐험하고 새로운 재미와 스릴을 느낄 수 있습니다.

### 주인공

![골드메탈 Asset 사용](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/%25EC%25B9%25BC%25EB%25A0%2588%25EC%259D%25B4%25EB%258F%2584_stage01_character.png)

골드메탈 Asset 사용

### 스테이지 컨셉

Stage01. 지하 감옥

Stage02. 감시방

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%201.png)

Stage03. 전기실

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%202.png)

Stage05. 실험실

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%203.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%204.png)

Stage04. 기계실

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%205.png)

## 게임 플레이 방식

---

|  | 좌 | 우 | 하 | 점프 | stage 리셋 |
| --- | --- | --- | --- | --- | --- |
| 키보드 | A | D | S | SPACE BAR | R |
| 방향키 | ← | → | ↓ | SPACE BAR | R |

### 아이템 (공통)

- 더블 점프: 획득한 아이템의 개수 만큼 더블 점프 가능
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%206.png)
    

### 함정 (공통)

- Spike: hp 1감소
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%207.png)
    

### 도착 (공통)

- finish: 다음 스테이지 이동
    
    ![finish](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%208.png)
    
    finish
    

---

### 스테이지 1 (지하감옥)

- 클리어 조건: 맵 내에 있는 유령 4개 획득한 후 finish 도착

![stage01. 유령 1](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%209.png)

stage01. 유령 1

![stage01. 유령 2](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2010.png)

stage01. 유령 2

![stage01. 유령 3](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2011.png)

stage01. 유령 3

![stage01. 유령 4](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2012.png)

stage01. 유령 4

- 몬스터 : 눈
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2013.png)
    

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2014.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2015.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2016.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2017.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2018.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2019.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2020.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2021.png)

---

### 스테이지 2 (감시방)

- 클리어 조건:
    - 열쇠 획득 후 잠금 해제
        
        ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2022.png)
        
    - 맵 내 코인 ??이상 획득 후 finish 도착
        
        ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2023.png)
        
- 몬스터 : monster
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2024.png)
    
- 함정: 떨어지는 platform
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2025.png)
    

- secret event: 공개하지 않는 함정이 존재 합니다!
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2026.png)
    

---

### 스테이지 3 (전기실)

- 클리어 조건:  finish 도착
- 몬스터 : 유령 & monster

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2027.png)

![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2024.png)

- 함정: 레이저
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2028.png)
    
- secret event: 공개하지 않는 함정이 존재 합니다!
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2026.png)
    

---

### 스테이지 4 (기계실)

- 클리어 조건:  스코어 600이상으로 finish 도착
- 몬스터 : machine
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2029.png)
    
- 함정: 소주
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2030.png)
    
- secret event: 공개하지 않는 함정이 존재 합니다!
    
    ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2026.png)
    
    ---
    
    ### 스테이지 5 (실험실)
    
    - 클리어 조건:  스코어 600이상으로 finish 도착
    - 몬스터 : 슬라임
        
        ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2031.png)
        
    - 아이템: 물약(hp를 1회복 시켜줍니다.)
        
        ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2032.png)
        
    - secret event: 공개하지 않는 함정이 존재 합니다!
        
        ![Untitled](%E1%84%8E%E1%85%AC%E1%84%8C%E1%85%A9%E1%86%BC%20%E1%84%92%E1%85%AC%E1%84%8B%E1%85%B4%20!%20(%2009%2009%20)%205b2b2a015f66458fbe947cedf843b6ef/Untitled%2026.png)
        


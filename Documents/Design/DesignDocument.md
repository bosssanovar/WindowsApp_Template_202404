# 基礎設計

- [1. 概要](#1-概要)
- [2. 要点](#2-要点)
- [3. システム要素](#3-システム要素)
- [4. アーキテクチャ設計](#4-アーキテクチャ設計)
- [5. システムアーキテクチャ設計](#5-システムアーキテクチャ設計)
  - [5.1. レイヤー設計](#51-レイヤー設計)
    - [5.1.1. Domain Model層](#511-domain-model層)
    - [5.1.2. Domain Service層](#512-domain-service層)
    - [5.1.3. Application Service層](#513-application-service層)
    - [5.1.4. Infrastructure層](#514-infrastructure層)
    - [5.1.5. User Interface層](#515-user-interface層)
  - [5.2. コンポーネント設計](#52-コンポーネント設計)
    - [5.2.1. Domain Model層コンポーネント](#521-domain-model層コンポーネント)
      - [5.2.1.1. 各種Entity](#5211-各種entity)
      - [5.2.1.2. Domain Model Common](#5212-domain-model-common)
    - [5.2.2. Domain Service層コンポーネント](#522-domain-service層コンポーネント)
      - [5.2.2.1. Domain Service](#5221-domain-service)
      - [5.2.2.2. Repository](#5222-repository)
    - [5.2.3. Application Service層コンポーネント](#523-application-service層コンポーネント)
      - [5.2.3.1. Usecase](#5231-usecase)
      - [5.2.3.2. Feature](#5232-feature)
    - [5.2.4. Infrastructure層コンポーネント](#524-infrastructure層コンポーネント)
      - [5.2.4.1. File Accessor](#5241-file-accessor)
      - [5.2.4.2. In Memory Repository](#5242-in-memory-repository)
    - [5.2.5. User Interface層コンポーネント](#525-user-interface層コンポーネント)
      - [5.2.5.1. UI Parts](#5251-ui-parts)
      - [5.2.5.2. WPF Lib](#5252-wpf-lib)
      - [5.2.5.3. WPF App](#5253-wpf-app)
  - [5.3. ユースケース](#53-ユースケース)
    - [5.3.1. 設定値表示](#531-設定値表示)
    - [5.3.2. 設定値確定](#532-設定値確定)
    - [5.3.3. 設定データ保存](#533-設定データ保存)
    - [5.3.4. 設定データ読み込み](#534-設定データ読み込み)
    - [5.3.5. 設定値初期化](#535-設定値初期化)
- [6. GUIアーキテクチャ設計](#6-guiアーキテクチャ設計)
  - [6.1. GUIレイヤー設計](#61-guiレイヤー設計)
    - [6.1.1. View層](#611-view層)
    - [6.1.2. Model層](#612-model層)
    - [6.1.3. ViewModel層](#613-viewmodel層)
  - [6.2. GUIコンポーネント設計](#62-guiコンポーネント設計)
    - [6.2.1. EntoryProject](#621-entoryproject)
    - [6.2.2. WPF Library](#622-wpf-library)
    - [6.2.3. UI Parts](#623-ui-parts)
  - [6.3. クラス構成](#63-クラス構成)
    - [6.3.1. MainWindow](#631-mainwindow)
    - [6.3.2. 汎用Dialog](#632-汎用dialog)
  - [6.4. シーケンス](#64-シーケンス)
    - [6.4.1. GUIインスタンス取得時](#641-guiインスタンス取得時)
    - [6.4.2. 画面遷移時](#642-画面遷移時)
    - [6.4.3. 設定値表示時](#643-設定値表示時)
    - [6.4.4. 設定値変更時](#644-設定値変更時)
    - [6.4.5. 設定値更新時](#645-設定値更新時)

## 1. 概要

製品仕様に大きく影響されない、設定用PCアプリケーションに共通的な部分に関する基礎設計を示す。

## 2. 要点

設計の要点は以下の通り。  

- aaa
- bbb

## 3. システム要素

システムで採用している要素片（設計パターン、ライブラリ、etc.）は以下の通り。  

- オニオンアーキテクチャ  
aaaaaaaaasdfkjal;skdfj;aksjdf  

- MVVM  
aaaaaaaaasdfkjal;skdfj;aksjdf  

- ReactiveProperty  
alks;djf;aksdj;fkasjdf;akj  

- Value Object  
kajlsdj;fkj;askjdf;as

- Entity  
kajlsdj;fkj;askjdf;as

- Behavior  
kajlsdj;fkj;askjdf;as

- DI (Dependency Injection)  
kajlsdj;fkj;askjdf;as

## 4. アーキテクチャ設計

PCアプリケーションを設計する上で、守備範囲の異なる「システムアーキテクチャ」と「GUIアーキテクチャ」のそれぞれの視点での設計を示す。

>システムアーキテクチャとは "GUI"アーキテクチャの汎用性を増したもの。  
さらに詳しくいうと、"システム"アーキテクチャは、"GUI"アーキテクチャよりも広い、UIという単位にとらわれることなくシステム全体の構造を示せるもの。
「システムアーキテクチャ > GUIアーキテクチャ」  

>GUIアーキテクチャは、Viewからの視点で、構造化設計を実践する際の具体的なレイヤー構造をパターンとして示したもの。  

＊＊＊＊＊＊＊＊＊＊＊＊＊＊構造図＊＊＊＊＊＊＊＊＊＊＊＊

## 5. システムアーキテクチャ設計

本章では、GUIアーキテクチャ範囲を除外したシステムアーキテクチャの設計を示す。

### 5.1. レイヤー設計

オニオンアーキテクチャの考え方に沿ったレイヤー設計として、以下のレイヤー分割を行った。

- Domain Model層
- Domain Service層
- Application Service層
- Infrastructure層
- User Interface層

＊＊＊＊＊＊＊＊玉ねぎの図＊＊＊＊＊＊＊＊＊

各層の機能概要を以下に示す。

#### 5.1.1. Domain Model層

- ビジネスドメインのコアロジックやビジネスルールを表現する。
- ドメインモデルはエンティティ、バリューオブジェクトなどで構成され、ビジネスオブジェクトとその振る舞いを表現する。

#### 5.1.2. Domain Service層

- ドメインモデルが持つ責務の一部を凝集させている
- ドメインモデルに直接関連する操作や、複数のドメインオブジェクトにまたがる操作を提供
- ドメインサービスは、ビジネスルールやビジネスロジックの実装を含む場合があり、ドメインモデルの一部として表現されることもある

#### 5.1.3. Application Service層

- アプリケーションの振る舞いを実装
- ユーザーインターフェースや外部APIとのやり取りを処理し、ビジネスロジックの組み立てやドメインモデルへの操作を行う
- アプリケーションサービスは、ドメインモデルの操作の組み合わせによってユースケースを実現する。
トランザクションの管理やエラーハンドリングも担当

#### 5.1.4. Infrastructure層

- データベース、キャッシング、外部サービス、ログ出力、メッセージングなど、外部要素とのやり取りを担当
- データの永続化や取得、外部サービスへのリクエストなど、ドメインモデルやアプリケーションサービスの要求を満たす役割

#### 5.1.5. User Interface層

GUIアーキテクチャの守備範囲のため、後述する。

### 5.2. コンポーネント設計

前述の各層の中に、それぞれの機能が凝集されたコンポーネントを配置する。

＊＊＊＊＊＊＊＊＊＊＊＊＊コンポーネント図＊＊＊＊＊＊＊＊＊＊＊＊＊＊

各層の各コンポーネントの詳細は以下に示す。

#### 5.2.1. Domain Model層コンポーネント

＊＊＊＊＊＊＊＊＊＊抜粋コンポーネント図＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊

Domain Model層のコンポーネント概要を以下に示す。

##### 5.2.1.1. 各種Entity

機能まとまり単位の設定値クラス群（Value Object）とその集約（EEntity）、またそれらの制限機能を配置するコンポーネント。  
設定値のインポート/エクスポートのためのプリミティブなデータのみを抱える小袋クラス（Data Packet）も定義する。

##### 5.2.1.2. Domain Model Common

#### 5.2.2. Domain Service層コンポーネント

##### 5.2.2.1. Domain Service

##### 5.2.2.2. Repository

#### 5.2.3. Application Service層コンポーネント

##### 5.2.3.1. Usecase

##### 5.2.3.2. Feature

#### 5.2.4. Infrastructure層コンポーネント

##### 5.2.4.1. File Accessor

##### 5.2.4.2. In Memory Repository

#### 5.2.5. User Interface層コンポーネント

##### 5.2.5.1. UI Parts

##### 5.2.5.2. WPF Lib

##### 5.2.5.3. WPF App

### 5.3. ユースケース

#### 5.3.1. 設定値表示

#### 5.3.2. 設定値確定

#### 5.3.3. 設定データ保存

#### 5.3.4. 設定データ読み込み

#### 5.3.5. 設定値初期化

## 6. GUIアーキテクチャ設計

### 6.1. GUIレイヤー設計

#### 6.1.1. View層

#### 6.1.2. Model層

#### 6.1.3. ViewModel層

### 6.2. GUIコンポーネント設計

#### 6.2.1. EntoryProject

#### 6.2.2. WPF Library

#### 6.2.3. UI Parts

### 6.3. クラス構成

#### 6.3.1. MainWindow

#### 6.3.2. 汎用Dialog

### 6.4. シーケンス

#### 6.4.1. GUIインスタンス取得時

#### 6.4.2. 画面遷移時

#### 6.4.3. 設定値表示時

#### 6.4.4. 設定値変更時

#### 6.4.5. 設定値更新時
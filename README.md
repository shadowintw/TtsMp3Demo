# TtsMp3Demo

**ASP.NET Core MVC 範例：TTSMP3 線上文字轉語音服務**

## 📖 專案介紹

本專案示範如何使用免費的網站端點 `ttsmp3.com/makemp3_new.php`，將使用者輸入的文字轉成 MP3，並在網頁上播放與下載。  
主要用途：
- 線上文字轉語音 (Text‑to‑Speech) Demo  
- 整合第三方 AJAX TTS 服務  
- 部署於 Azure App Service 的範例  

## 🚀 功能

1. 使用者於文字框輸入內容  
2. 選擇語者（預設 Matthew, English）  
3. 按下「轉換」，呼叫第三方 TTS 接口並回傳 MP3 URL  
4. 網頁自動顯示播放器與下載連結  
5. 播放速率預設 0.75  

## 🛠️ 環境需求

- .NET 6 SDK  
- Visual Studio 2022 / VS Code  
- Azure CLI（若要部署 Azure）  

## 🔧 安裝與執行

```bash
# 複製專案
git clone https://github.com/YourUserName/TtsMp3Demo.git
cd TtsMp3Demo

# 編譯並執行
dotnet restore
dotnet run

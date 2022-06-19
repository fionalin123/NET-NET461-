# C# 開發實戰：非同步程式開發技巧

此專案為【C# 開發實戰：非同步程式開發技巧】課程的範例程式。

## 建置方式 (Visual Studio 2022)

1. 開啟 `NET非同步程式設計(NET461).sln` 方案檔

2. 按下 `Ctrl+Shift+B` 或 `F6` 進行方案建置

    > 沒有出現錯誤訊息就是成功建置方案！

## 建置方式 (命列列工具)

1. 執行 `開始` > `Visual Studio 2022` > `Developer Command Prompt for VS 2022`

2. 使用 [Chocolatey](https://chocolatey.org/install) 安裝 NuGet 命令列工具

   ```sh
   choco install nuget.commandline -y
   ```

3. 進入專案目錄

   ```sh
   cd C:\Projects\CSharpAsync_NET461
   ```

4. 還原 NuGet 套件

   ```sh
   nuget restore
   ```

5. 透過 MSBuild 進行方案建置

   ```sh
   msbuild
   ```

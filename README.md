# 📈 Stock Price Tracker

A simple C# console application that simulates changes in stock prices and visually displays price trends using color-coded output.

## 🚀 Features

- Track price changes for multiple stocks.
- Detect and display:
  - 🔼 **Price increase** in green.
  - 🔽 **Price decrease** in red.
  - ⚪ **No change** in white.
- Uses event delegation to react to price changes.

## 🛠️ How It Works

- Each `Stock` instance has:
  - A name (e.g., "Amazon", "Apple")
  - A price
  - An event `OnPriceChanged` triggered on price change

- Price is changed via:
  ```csharp
  stock.ChangeStockPriceBy(percentage);

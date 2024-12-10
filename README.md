# PrivateBrowser

A privacy-focused web browser built with modern .NET technologies that prioritizes user privacy and security.

## Features

- 🛡️ **Tracker Blocking**: Built-in protection against common web trackers and advertisers
- 🔒 **Encrypted History**: Browser history is stored with encryption for enhanced privacy
- 🧹 **Privacy Controls**: Easy-to-use controls for clearing browsing history
- 🌐 **Modern Web Support**: Built on Microsoft's WebView2 engine for full modern web compatibility
- ⚡ **Standard Navigation**: Familiar browser controls including back, forward, and refresh

## Technology Stack

- C# / .NET
- WPF (Windows Presentation Foundation)
- Microsoft WebView2
- MVVM Architecture with Prism Framework
- AES Encryption for secure data storage

## Getting Started

### Prerequisites

- Windows OS
- .NET Runtime
- Microsoft Edge WebView2 Runtime

### Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/PrivateBrowser.git
```

2. Open `PrivateBrowser.sln` in Visual Studio

3. Build and run the solution

## Usage

1. Launch the application
2. Use the address bar to navigate to websites
3. The tracker blocker will automatically protect against known tracking domains
4. View your encrypted browsing history using the history button
5. Clear history at any time for enhanced privacy

## Security Features

- **Tracker Blocking**: Maintains a list of known tracking domains and automatically blocks requests to these domains
- **Encrypted Storage**: All browsing history is encrypted using AES encryption before being stored locally
- **Privacy Controls**: Simple interface for managing and clearing browsing data

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

MIT License

Copyright (c) 2024 PrivateBrowser

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## Acknowledgments

- Built with Microsoft WebView2
- Uses Prism Framework for MVVM architecture

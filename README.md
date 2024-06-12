# Stochastica

This repository is dedicated to the implementation of the Stochastica application, developed as part of a proposed challenge. The application is a tool for simulating Brownian motion, commonly used in finance to model the stochastic behavior of prices.

## Summary
### Key features

1. **Brownian Motion Visualization**: Generation of real-time Brownian motion paths, demonstrating stochastic behaviors through interactive graphs.
2. **User-Controlled Parameters**: Customizable parameters for simulations, such as time steps, drift, volatility, and more, to explore different scenarios and outcomes.
3. **Multi-Platform Support**: Seamless performance on Windows, macOS, iOS, and Android, leveraging .NET MAUI's cross-platform capabilities.
4. **Interactive Graph**s: Implementation of responsive and interactive graphs using powerful charting libraries, enabling zoom, pan, and detailed inspection of data points.
5. **Educational Tools**: Inclusion of descriptive statistics and tools to help users understand the underlying mathematics and applications of Brownian motion.
   
### Skills and Technologies

1. **.NET MAUI**: Utilized .NET MAUI for developing a single codebase application that runs on multiple platforms with a native look and feel.
2. **C# and .NET**: Employed C# and the .NET framework for core logic and mathematical computations behind the Brownian motion simulations.
3. **SkiaSharp for MAUI**: Integrated SkiaSharp for rendering high-quality and interactive graphs, providing smooth visualization of stochastic paths.
4. **MVVM Pattern**: Followed the MVVM (Model-View-ViewModel) architecture to ensure a clean separation of concerns, facilitating easier maintenance and testing.
5. **XAML**: Used XAML for designing the UI, enabling clear and maintainable user interface code.
6. **Async and Parallel Programming**: Leveraged async and parallel programming techniques to handle real-time graph updates and computations without blocking the UI.
7. **Cross-Platform Compatibility**: Ensured consistent behavior and appearance across various devices and operating systems by addressing platform-specific challenges.
8. **Data Binding**: Implemented robust data binding to synchronize user input and application state, enhancing the responsiveness and interactivity of the UI.

### Educational Value

1. **Stochastic Processes**: Provides users with an interactive tool to study and visualize Brownian motion, offering insights into stochastic processes.
2. **Hands-On Learning**: Enhances learning through visualization, making abstract mathematical concepts more accessible and engaging.
3. **Application in Finance and Physics**: Demonstrates practical applications in fields such as quantitative finance for modeling stock prices and in physics for particle motion.

## Proposal

The purpose of the Stochastica application is to provide a user-friendly and functional interface for simulating Brownian motion, allowing users to configure various parameters and view the results clearly and intuitively.

## Enhancements

In addition to the minimum challenge requirements, the following enhancements have been implemented:

- **Scale System:** Added vertical and horizontal scales to the graph to facilitate result interpretation.
- **Multiple Simulations:** Users can now simulate multiple outcomes, defining the desired number of simulations and viewing all lines on the same graph.
- **Enhanced Components:** Components such as steppers and sliders have been used for parameter input, improving the user experience.
- **Visual Customization:** Users can visually customize the graph by choosing the number of plot lines and using an automatic contrasting color selection system.
- **Improved Responsiveness:** The application was developed with a focus on responsiveness, ensuring a consistent experience across different devices and screen sizes.

## Standards and Best Practices

The implementation of the Stochastica application strictly follows these standards and best practices:

- Use of the MVVM (Model-View-ViewModel) pattern for clear separation of responsibilities and a modular, scalable architecture.
- Adoption of Microsoft's design guidelines to ensure a consistent and user-friendly interface.
- Compliance with .NET coding standards to ensure code readability, maintainability, and performance.
- Implementation of unit tests using frameworks such as NUnit or MSTest to ensure software quality and facilitate regression detection.
- Use of comments in the code to explain the logic, making it easier for other developers to understand and maintain.

## Screenshot of the Working Application

![Stochastica-RealApplication](https://github.com/LuccaGiffoni/Stochastica/assets/81778943/ca416461-e804-4e44-9df3-52a778f87c35)

# Anaglyph 3D Photo Generator

> Anaglyph 3D is the name given to the stereoscopic 3D effect achieved by means of encoding each eye's image using filters of different (usually chromatically opposite) colors, typically red and cyan. Anaglyph 3D images contain two differently filtered colored images, one for each eye. When viewed through the "color-coded" "anaglyph glasses", each of the two images reaches the eye it's intended for, revealing an integrated stereoscopic image. The visual cortex of the brain fuses this into the perception of a three-dimensional scene or composition.

## About
This project was created in 2016 as student project. \
In January 2018 I decided to little refactoring and publishing it for open source. \

I implemented several types of algorithms:
- True Anaglyph,
- Gray Anaglyph (monochrome anaglyph),
- Color Anaglyph (Photoshop algorithm),
- Half-color Anaglyph (modified Photoshop algorithm),
- Optimized Anaglyph

## Examples
In folder **Content/uploads** I added example images for upload and anaglyph creation.

## Frameworks
- ASP.NET MVC 5 (with Razor)
- Bootstrap 3

## TODO
- Write tests.
- Move logic from HomeController to another class.
- Use Dependency Injection for inject list of algorithm in AnaglyphAlgorithmInvoker.

## References
 - https://en.wikipedia.org/wiki/Anaglyph_3D

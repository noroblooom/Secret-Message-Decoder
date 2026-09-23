# Secret Message Decoder

A small C# project that reads a text file containing coordinate-based block characters and reconstructs the hidden message in the terminal.

## What it does

The program reads a file like this:

```text
0 █ 4
1 █ 4
2 █ 4
3 █ 4
4 █ 4
0 █ 3
...
```

Each line follows the format:

```text
x symbol y
```

The decoder:

- parses the coordinates
- builds a 2D character grid
- flips the Y-axis so the message renders correctly
- prints the final message to the console

## Example

The default example file is `hello.txt`.

When run, it generates a `HELLO` message in block characters.

## Run it

From the project folder:

```bash
dotnet run
```

## File structure

- `Program.cs` – starts the decoder with the sample file
- `SecretMessageDecoder.cs` – parses the file and renders the decoded grid
- `hello.txt` – example encoded message

## Notes

This project is a simple interview-style coding exercise designed to show:

- coordinate parsing
- grid reconstruction
- terminal rendering
- troubleshooting Unicode output in Windows consoles

## License

This project is provided for educational and portfolio use.

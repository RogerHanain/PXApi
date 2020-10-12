using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SXFileManager.Document
{
    //Copié collé depuis le F12 sur StreamWriter
    public interface IPXStreamWriter : IDisposable, IAsyncDisposable
    {
        //
        // Summary:
        //     Gets or sets a value indicating whether the System.IO.StreamWriter will flush
        //     its buffer to the underlying stream after every call to System.IO.StreamWriter.Write(System.Char).
        //
        // Returns:
        //     true to force System.IO.StreamWriter to flush its buffer; otherwise, false.
        bool AutoFlush { get; set; }
        //
        // Summary:
        //     Gets the underlying stream that interfaces with a backing store.
        //
        // Returns:
        //     The stream this StreamWriter is writing to.
        Stream BaseStream { get; }
        //
        // Summary:
        //     Gets the System.Text.Encoding in which the output is written.
        //
        // Returns:
        //     The System.Text.Encoding specified in the constructor for the current instance,
        //     or System.Text.UTF8Encoding if an encoding was not specified.
        Encoding Encoding { get; }
        //
        // Summary:
        //     Closes the current StreamWriter object and the underlying stream.
        //
        // Exceptions:
        //   T:System.Text.EncoderFallbackException:
        //     The current encoding does not support displaying half of a Unicode surrogate
        //     pair.
        void Close();
     
        //
        // Summary:
        //     Clears all buffers for the current writer and causes any buffered data to be
        //     written to the underlying stream.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The current writer is closed.
        //
        //   T:System.IO.IOException:
        //     An I/O error has occurred.
        //
        //   T:System.Text.EncoderFallbackException:
        //     The current encoding does not support displaying half of a Unicode surrogate
        //     pair.
        void Flush();
        //
        // Summary:
        //     Clears all buffers for this stream asynchronously and causes any buffered data
        //     to be written to the underlying device.
        //
        // Returns:
        //     A task that represents the asynchronous flush operation.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The stream has been disposed.
        Task FlushAsync();
        //
        // Summary:
        //     Writes a subarray of characters to the stream.
        //
        // Parameters:
        //   buffer:
        //     A character array that contains the data to write.
        //
        //   index:
        //     The character position in the buffer at which to start reading data.
        //
        //   count:
        //     The maximum number of characters to write.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     buffer is null.
        //
        //   T:System.ArgumentException:
        //     The buffer length minus index is less than count.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     index or count is negative.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.ObjectDisposedException:
        //     System.IO.StreamWriter.AutoFlush is true or the System.IO.StreamWriter buffer
        //     is full, and current writer is closed.
        //
        //   T:System.NotSupportedException:
        //     System.IO.StreamWriter.AutoFlush is true or the System.IO.StreamWriter buffer
        //     is full, and the contents of the buffer cannot be written to the underlying fixed
        //     size stream because the System.IO.StreamWriter is at the end the stream.
        void Write(char[] buffer, int index, int count);
       
        //
        // Summary:
        //     Writes a character to the stream.
        //
        // Parameters:
        //   value:
        //     The character to write to the stream.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.ObjectDisposedException:
        //     System.IO.StreamWriter.AutoFlush is true or the System.IO.StreamWriter buffer
        //     is full, and current writer is closed.
        //
        //   T:System.NotSupportedException:
        //     System.IO.StreamWriter.AutoFlush is true or the System.IO.StreamWriter buffer
        //     is full, and the contents of the buffer cannot be written to the underlying fixed
        //     size stream because the System.IO.StreamWriter is at the end the stream.
        void Write(char value);
      
        Task WriteAsync(char value);
        //
        // Summary:
        //     Asynchronously writes a subarray of characters to the stream.
        //
        // Parameters:
        //   buffer:
        //     A character array that contains the data to write.
        //
        //   index:
        //     The character position in the buffer at which to begin reading data.
        //
        //   count:
        //     The maximum number of characters to write.
        //
        // Returns:
        //     A task that represents the asynchronous write operation.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     buffer is null.
        //
        //   T:System.ArgumentException:
        //     The index plus count is greater than the buffer length.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     index or count is negative.
        //
        //   T:System.ObjectDisposedException:
        //     The stream writer is disposed.
        //
        //   T:System.InvalidOperationException:
        //     The stream writer is currently in use by a previous write operation.
        Task WriteAsync(char[] buffer, int index, int count);
        //
        // Summary:
        //     Writes a string to the stream, followed by a line terminator.
        //
        // Parameters:
        //   value:
        //     The string to write. If value is null, only the line terminator is written.
        void WriteLine(string value);
        //
        // Summary:
        //     Asynchronously writes a line terminator to the stream.
        //
        // Returns:
        //     A task that represents the asynchronous write operation.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The stream writer is disposed.
        //
        //   T:System.InvalidOperationException:
        //     The stream writer is currently in use by a previous write operation.
        Task WriteLineAsync();
        //
        // Summary:
        //     Asynchronously writes a character to the stream, followed by a line terminator.
        //
        // Parameters:
        //   value:
        //     The character to write to the stream.
        //
        // Returns:
        //     A task that represents the asynchronous write operation.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The stream writer is disposed.
        //
        //   T:System.InvalidOperationException:
        //     The stream writer is currently in use by a previous write operation.
        Task WriteLineAsync(char value);
        //
        // Summary:
        //     Asynchronously writes a subarray of characters to the stream, followed by a line
        //     terminator.
        //
        // Parameters:
        //   buffer:
        //     The character array to write data from.
        //
        //   index:
        //     The character position in the buffer at which to start reading data.
        //
        //   count:
        //     The maximum number of characters to write.
        //
        // Returns:
        //     A task that represents the asynchronous write operation.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     buffer is null.
        //
        //   T:System.ArgumentException:
        //     The index plus count is greater than the buffer length.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     index or count is negative.
        //
        //   T:System.ObjectDisposedException:
        //     The stream writer is disposed.
        //
        //   T:System.InvalidOperationException:
        //     The stream writer is currently in use by a previous write operation.
        Task WriteLineAsync(char[] buffer, int index, int count);
    }
}
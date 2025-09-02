export const saveFile = (contents: string, type: string, name: string) => {
  // Create a Blob from the XML string
  const blob = new Blob([contents], { type });

  // Create an invisible <a> element
  const a = document.createElement("a");
  document.body.appendChild(a);
  a.style.display = "none";

  // Create a URL for the Blob
  const url = window.URL.createObjectURL(blob);
  a.href = url;

  // Set the file name
  a.download = name;

  // Simulate clicking the <a> element
  a.click();

  // Release the created URL
  window.URL.revokeObjectURL(url);

  // Remove the <a> element
  document.body.removeChild(a);
};

export const openFile = (accept: string, onOpen: (result: string) => void) => {
  // Create an invisible file input element
  const input: HTMLInputElement = document.createElement("input");
  input.type = "file";
  input.accept = accept;
  input.style.display = "none";
  input.multiple = true;

  // Append it to the body
  document.body.appendChild(input);

  // This function will be called when the user selects a file
  input.onchange = (event: Event) => {
    for (const file of (event.target as HTMLInputElement).files) {
      const reader: FileReader = new FileReader();

      reader.onload = (e: ProgressEvent<FileReader>) => {
        // The file's text will be printed here
        const result: string = e.target.result as string;

        onOpen(result);
      };

      // Read the file as text
      reader.readAsText(file);
    }
  };

  // Simulate a click on the file input
  input.click();
};

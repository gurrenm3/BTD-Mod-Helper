export const saveFile = (fileName: string, blob: Blob) => {
  // Create a URL for the Blob
  const url = window.URL.createObjectURL(blob);

  // Create an anchor element and trigger a download
  const a = document.createElement("a");
  a.href = url;
  a.download = fileName; // The name of the file
  document.body.appendChild(a);
  a.click(); // Trigger the download
  document.body.removeChild(a); // Remove the anchor after download

  // Clean up the URL object
  window.URL.revokeObjectURL(url);
};

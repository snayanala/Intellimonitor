import React, { useState, useEffect } from "react";


interface Monitor {
  id: number;
  url: string;
  email: string;
  scheduledTime: string;
}

function App() {
  const [url, setUrl] = useState("");
  const [email, setEmail] = useState("");
  const [scheduledTime, setScheduledTime] = useState("");
  const [monitors, setMonitors] = useState<Monitor[]>([]);

  const fetchMonitors = async () => {
    const response = await fetch("http://localhost:5125/api/monitor");
    const data = await response.json();
    setMonitors(data);
  };

  useEffect(() => {
    fetchMonitors();
  }, []);

  const handleSubmit = async () => {
    await fetch("http://localhost:5125/api/monitor", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        url,
        email,
        scheduledTime
      })
    });

    setUrl("");
    setEmail("");
    setScheduledTime("");

    fetchMonitors();
  };

  return (
    <div style={{ padding: "40px", fontFamily: "Arial" }}>
    
      <h1>IntelliMonitor</h1>
      <h3>AI-powered website monitoring assistant</h3>

      <div style={{ marginBottom: "20px" }}>
        <input
          placeholder="Website URL"
          value={url}
          onChange={(e) => setUrl(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          type="datetime-local"
          value={scheduledTime}
          onChange={(e) => setScheduledTime(e.target.value)}
        />
        <button onClick={handleSubmit} style={{ marginLeft: "10px" }}>
          Start Monitoring
        </button>
      </div>

      <h2>Active Monitors</h2>
      <ul>
        {monitors.map((monitor) => (
          <li key={monitor.id}>
            {monitor.url} → {monitor.email}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;


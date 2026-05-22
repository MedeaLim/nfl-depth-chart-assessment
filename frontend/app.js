const API_BASE_URL = "http://localhost:5237";

function showMessage(message) {
  document.getElementById("message").textContent = message;
}

function clearResult(id) {
  document.getElementById(id).textContent = "";
}

async function getDepthChart() {
  const position = document.getElementById("chartPosition").value.trim();

  const response = await fetch(`${API_BASE_URL}/api/DepthChart/${position}`);

  if (!response.ok) {
    showMessage("Failed to load depth chart.");
    return;
  }

  const data = await response.json();

  document.getElementById("depthChartResult").textContent =
    JSON.stringify(data, null, 2);

  showMessage("Depth chart loaded.");
}

async function getBackups() {
  const position = document.getElementById("backupPosition").value.trim();
  const playerNumber = parseInt(
    document.getElementById("backupPlayerNumber").value
  );

  const response = await fetch(
    `${API_BASE_URL}/api/DepthChart/${position}/backups/${playerNumber}`
  );

  if (!response.ok) {
    showMessage("Failed to load backups.");
    return;
  }

  const data = await response.json();

  document.getElementById("backupsResult").textContent =
    JSON.stringify(data, null, 2);

  showMessage("Backups loaded.");
}

async function addPlayer() {
  const position = document.getElementById("addPosition").value.trim();
  const playerNumber = parseInt(
    document.getElementById("addPlayerNumber").value
  );
  const playerName = document.getElementById("addPlayerName").value.trim();
  const depthOrder = parseInt(document.getElementById("addDepth").value);

  const player = {
    playerNumber: playerNumber,
    name: playerName,
    position: position,
    depthOrder: depthOrder
  };

  const response = await fetch(`${API_BASE_URL}/api/DepthChart/add`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(player)
  });

  if (response.ok) {
    showMessage("Player added successfully.");

    document.getElementById("addPosition").value = "";
    document.getElementById("addPlayerNumber").value = "";
    document.getElementById("addPlayerName").value = "";
    document.getElementById("addDepth").value = "";
  } else {
    showMessage("Failed to add player.");
  }
}

async function removePlayer() {
  const position = document.getElementById("removePosition").value.trim();
  const playerNumber = parseInt(
    document.getElementById("removePlayerNumber").value
  );

  const request = {
    position: position,
    playerNumber: playerNumber
  };

  const response = await fetch(`${API_BASE_URL}/api/DepthChart/remove`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(request)
  });

  if (response.ok) {
    showMessage("Player removed successfully.");

    document.getElementById("removePosition").value = "";
    document.getElementById("removePlayerNumber").value = "";
  } else {
    showMessage("Failed to remove player.");
  }
}

document
  .getElementById("getDepthChartBtn")
  .addEventListener("click", getDepthChart);

document
  .getElementById("getBackupsBtn")
  .addEventListener("click", getBackups);

document
  .getElementById("addPlayerBtn")
  .addEventListener("click", addPlayer);

document
  .getElementById("removePlayerBtn")
  .addEventListener("click", removePlayer);